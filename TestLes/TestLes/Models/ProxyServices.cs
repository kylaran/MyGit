using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Services.Client;
using System.Net;
using System.IO;
using TestLes.ProxyClasses;

namespace TestLes.Models
{
    public class ProxyServices
    {
        private static Uri serverUri = new Uri("http://shedko.beesender.com/0/serviceModel/entitydataservice.svc");
        private static BPMonline context = new BPMonline(serverUri);
        public static void OnSendingRequestCookie(object sender, SendingRequestEventArgs e)
        {
            Login.TryLogin();
            var req = e.Request as HttpWebRequest;
            req.CookieContainer = Login.AuthCookie;
            e.Request = req;
        }
        public static IEnumerable<Contact> GetOdataCollection(int take = 40)
        {
            IEnumerable<Contact> allContacts = null;
            context.SendingRequest += new EventHandler<SendingRequestEventArgs>(OnSendingRequestCookie);
            try
            {
                allContacts = (from contacts in context.ContactCollection.OrderByDescending(p => p.CreatedOn)
                              select contacts).Take(take);
            }
            catch (Exception ex)
            { }
            return allContacts;
                }
        public static void CreateContact(Contact contact)
        {
            context.SendingRequest += new EventHandler<SendingRequestEventArgs>(OnSendingRequestCookie);
            char delimeter = ' ';
            contact.Dear = contact.Name.Split(delimeter)[0];
            context.AddToContactCollection(contact);
            DataServiceResponse responses = context.SaveChanges(SaveChangesOptions.Batch);
        }
        public static void UpdateContact(Contact contact)
        {
            context.SendingRequest += new EventHandler<SendingRequestEventArgs>(OnSendingRequestCookie);
            var updateContact = context.ContactCollection.Where(c => c.Id.Equals(contact.Id)).First();
            updateContact.Name = contact.Name;
            updateContact.Dear = contact.Dear;
            updateContact.MobilePhone = contact.MobilePhone;
            updateContact.JobTitle = contact.JobTitle;
            updateContact.BirthDate = contact.BirthDate;
            context.UpdateObject(updateContact);
            var responces = context.SaveChanges(SaveChangesOptions.Batch);
        }
        public static void DeleteContact(Guid contactId)
        {
            context.SendingRequest += new EventHandler<SendingRequestEventArgs>(OnSendingRequestCookie);
            var deleteContact = context.ContactCollection.Where(c => c.Id.Equals(contactId)).First();
            context.DeleteObject(deleteContact);
            var responces = context.SaveChanges(SaveChangesOptions.Batch);
        }
    }
}