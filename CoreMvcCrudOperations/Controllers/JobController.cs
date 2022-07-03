using CoreMvcCrudOperations.DataAccess;
using CoreMvcCrudOperations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreMvcCrudOperations.Controllers
{
    public class JobController : Controller
    {
        Context context=new Context();  
        public IActionResult Index()
        {
            var jobList = context.Jobs.ToList();
            return View(jobList);
        }
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            context.Jobs.Add(job);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteJob(int id)
        {
            var deletedJob = context.Jobs.Find(id);
            context.Jobs.Remove(deletedJob);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateJob(int id)
        {
            var updatedJob = context.Jobs.Find(id);
            return View("UpdateJob",updatedJob);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            var updatedJob = context.Jobs.Find(job.JobId);
            updatedJob.JobName=job.JobName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
