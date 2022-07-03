using CoreMvcCrudOperations.DataAccess;
using CoreMvcCrudOperations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreMvcCrudOperations.Controllers
{
    public class PersonelController : Controller
    {
        Context context=new Context();
        public IActionResult Index()
        {
            var personelList = context.Personels.Include(x => x.Job).ToList();
            return View(personelList);
        }
        public IActionResult AddPersonel(int id)
        {
            List<SelectListItem> personelList = (from item in context.Jobs.ToList()
                                          select new SelectListItem
                                          {
                                              Text=item.JobName,
                                              Value=item.JobId.ToString()
                                          }).ToList();
            ViewBag.PersonelList = personelList;
            return View();
        }
        [HttpPost]
        public IActionResult AddPersonel(Personel personel)
        {
            var addedPersonel = context.Jobs.Where(x => x.JobId == personel.Job.JobId).FirstOrDefault();
            personel.Job= addedPersonel;
            context.Personels.Add(personel); 
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeletePersonel(int id)
        {
            var deletedPersonel = context.Personels.Find(id);
            context.Personels.Remove(deletedPersonel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePersonel(int id)
        {
            List<SelectListItem> personelList = (from item in context.Jobs.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = item.JobName,
                                                     Value = item.JobId.ToString()
                                                 }).ToList();
            ViewBag.PersonelList = personelList;
            var updatedPersonel = context.Personels.Find(id);

            return View(updatedPersonel);
            
        }
        [HttpPost]
        public IActionResult UpdatePersonel(Personel personel)
        {
            var updatedPersonel = context.Personels.Find(personel.PersonelId);
            updatedPersonel.PersonelName = personel.PersonelName;
            updatedPersonel.PersonelSurname = personel.PersonelSurname;
            updatedPersonel.City=personel.City;
            var personelJob = context.Jobs.Where(x => x.JobId == personel.Job.JobId).FirstOrDefault();
            updatedPersonel.Job=personelJob;


            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
