using Creed.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Creed.UI.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            List<Process> listProcesses = ProcessDBContext.List();

            return View(listProcesses);
        }


        // GET: Process/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Process/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            // create the process object and save it
            string processName = collection.Get("ProcessName");
            string processDescription = collection.Get("ProcessDescription");

            Process p = new Process(processName, processDescription);
            ProcessDBContext.Save(p);

            return RedirectToAction("Index");
        }

        // GET: Process/Delete
        public ActionResult Delete(int processKey)
        {
            ProcessDBContext.Delete(processKey);
            return RedirectToAction("Index");
        }

    }
}