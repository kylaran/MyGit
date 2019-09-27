using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestLes.Models;
using TestLes.ProxyClasses;

namespace BPMService.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IEnumerable<Contact> contactsApi;

        public HomeController()
        {
            if (Login.TryLogin())
            {
                //ViewBag.Contacts = EDProxyService.GetOdataCollection();
                contactsApi = ProxyServices.GetOdataCollection();
            }
        }

        public ActionResult Index()
        {
            return View(contactsApi);
        }

        public ViewResult Create()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult Create(Contact newContact)
        {
            if (ModelState.IsValid)
            {
                ProxyServices.CreateContact(newContact);
                TempData["message"] = string.Format("Контакт {0} был создан", newContact.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newContact);
            }

        }

        public ViewResult Edit(Guid contactId)
        {
            Contact contact = contactsApi.FirstOrDefault(p => p.Id == contactId);
            return View(contact);
        }

        [HttpPost]
        public ActionResult Save(Contact contact)
        {
            if (ModelState.IsValid)
            {
                ProxyServices.UpdateContact(contact);
                TempData["message"] = string.Format("Изменения контакта {0} были сохранены", contact.Name);
                //return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = string.Format("Изменения контакта {0} не были сохранены", contact.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid contactId)
        {
            if (ModelState.IsValid)
            {
                ProxyServices.DeleteContact(contactId);
                TempData["message"] = "Удаление контакта было произведено";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}