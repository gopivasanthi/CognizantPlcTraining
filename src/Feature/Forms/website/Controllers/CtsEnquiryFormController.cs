using CognizantPlc.Feature.Forms.Models;
using Sitecore.Data;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websites.Controllers
{
    public class CtsEnquiryFormController : Controller
    {
        // GET: CtsEnquiryForm
        public ActionResult Index()
        {
            CustomerEnquiry customerEnquiry = new CustomerEnquiry();
            return View(customerEnquiry);
        }

        [HttpPost]
        public ActionResult Index(CustomerEnquiry customerEnquiry)
        {

            //take the parent item to create the enquiry item under it. 
            var contextItem = Sitecore.Context.Item;
            //Get master db
            Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
            //parentitem from the master db
            var parentItemFromMaster = masterDb.GetItem(contextItem.ID);
            //template
            var templateId = new TemplateID(new ID("{C0F3BD69-36B3-4BBC-AC1E-801B1F9C1902}"));
            //create the enquiry item

            using (new SecurityDisabler())
            {
                var createdItem = parentItemFromMaster.Add(customerEnquiry.Name, templateId);
                createdItem.Editing.BeginEdit();
                //populate the fields 
                createdItem.Fields["CustomerName"].Value = customerEnquiry.Name;
                createdItem.Fields["CustomerEmailId"].Value = customerEnquiry.EmailId;
                createdItem.Fields["CustomerPhoneNumber"].Value = customerEnquiry.PhoneNumber;
                createdItem.Fields["CustomerQuery"].Value = customerEnquiry.Enquiry;
                createdItem.Editing.EndEdit();
                
            }
            return View("EnquirySubmissionSuccess");
        }
    }
}