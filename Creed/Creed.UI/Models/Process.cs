using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;


namespace Creed.UI.Models
{
    public class Process
    {
        public int ProcessKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Creates a process object
        /// </summary>
        /// <param name="processKey"></param>
        /// <param name="processName"></param>
        /// <param name="processDescription"></param>
        public Process(int processKey, string processName, string processDescription)
        {
            ProcessKey = processKey;
            Name = processName;
            Description = processDescription;
        }

        /// <summary>
        /// Creates a process with the name and description
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="processDescription"></param>
        public Process(string processName, string processDescription)
        {
            ProcessKey = -1;
            Name = processName;
            Description = processDescription;
        }
    }

    public class ProcessDBContext
    {
        private static string GetConnectionString()
        {
            Configuration c = WebConfigurationManager.OpenWebConfiguration("/Creed.UI");
            return c.ConnectionStrings.ConnectionStrings["CreedDB"].ConnectionString;
        }

        public static void Save(Process p)
        {
            if (Exists(p))
            {
                Update(p);
            }
            else
            {
                Create(p);
            }
        }

        private static void Create(Process p)
        {
            // open a connection to sql server
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                // generate the command to see if the process exists
                using (SqlCommand cmd = new SqlCommand("EXEC dbo.CreateProcess @ProcessName, @ProcessDescription", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProcessName", p.Name));
                    cmd.Parameters.Add(new SqlParameter("@ProcessDescription", p.Description));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void Update(Process p)
        {
            // open a connection to sql server
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                // generate the command to see if the process exists
                using (SqlCommand cmd = new SqlCommand("EXEC dbo.UpdateProcess @ProcessKey, @ProcessName, @ProcessDescription", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProcessKey", p.ProcessKey));
                    cmd.Parameters.Add(new SqlParameter("@ProcessName", p.Name));
                    cmd.Parameters.Add(new SqlParameter("@ProcessDescription", p.Description));
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Process Find(int processKey)
        {
            // open a connection to sql server
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                // generate the command to see if the process exists
                using (SqlCommand cmd = new SqlCommand("SELECT ProcessKey, ProcessName, ProcessDescription FROM dbo.Process WHERE ProcessKey = @ProcessKey", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProcessKey", processKey));
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    reader.Read();
                    return new Process((int)reader["ProcessKey"], (string)reader["ProcessName"], (string)reader["ProcessDescription"]);
                }
            }
        }

        public static bool Exists(Process p)
        {
            return Exists(p.ProcessKey);
        }

        public static bool Exists(int processKey)
        {
            // open a connection to sql server
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                // generate the command to see if the process exists
                using (SqlCommand cmd = new SqlCommand("SELECT ProcessKey FROM dbo.Process WHERE ProcessKey = @ProcessKey", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@ProcessKey", processKey));
                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }

        public static List<Process> List()
        {
            List<Process> processes = new List<Process>();

            // open a connection to sql server
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                // generate the command to see if the process exists
                using (SqlCommand cmd = new SqlCommand("SELECT ProcessKey, ProcessName, ProcessDescription FROM dbo.Process", conn))
                {
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        processes.Add(new Process(reader.GetInt32(0), (string)reader["ProcessName"], (string)reader["ProcessDescription"]));
                    }
                }
            }

            return processes;
        }


        public static void Delete(Process p)
        {
            Delete(p.ProcessKey);
        }

        public static void Delete(int processKey)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Process WHERE ProcessKey = @ProcessKey", conn);
                cmd.Parameters.Add(new SqlParameter("@ProcessKey", processKey));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}