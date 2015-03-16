using System;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week7CodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Who()
        {
            return View();
        }
        public ActionResult What()
        {
            return View();
        }
        public ActionResult Where()
        {
            return View();
        }
        public ActionResult Why()
        {
            return View();
        }
        public ActionResult How()
        {
            return View();
        }

        public ActionResult Work()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Careers()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public class ContactController : Controller
        {
            // GET: Contact
            [HttpGet]
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";
                //or can do here: Models.ContactForm contactForm = new Models.ContactForm(); --then pass "contactForm" instead
                return View(new Models.ContactForm());
            }

            [HttpPost]
            public ActionResult Contact(Models.ContactForm contactForm)
            {
                //(add the form to the database)
                //step 1: create the data context
                Models.Entities db = new Models.Entities();
                //try doing something...
                try
                {
                    //set the date created
                    contactForm.DateCreated = DateTime.Now; //referencing our "DateCreated" column from the database

                    //adding something to the database...
                    //step 2: add the object to the table
                    db.ContactForms.Add(contactForm);
                    //step 3: save
                    db.SaveChanges();
                }
                catch (Exception ex) //ex is short for "exception"
                {
                    //if it blows up, do this...
                    ViewBag.Error = ex.Message; //error handling here
                    return View("Error"); //there's already a built-in thing for this in the "Shared" Views folder
                }
                //mail us a copy
                //SMTP: Simple Mail Transfer Protocol
                //host: mail.dustinkraft.com
                //port: 587
                //user: bevanswd@gmail.com
                //password: techIsFun1

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(contactForm.Email); //this can be anything, as long as it's an email address
                mail.To.Add("bevanswd@gmail.com");
                mail.Subject = "new message from: " + contactForm.Name;
                mail.Body = contactForm.Message;

                //connecting to the actual email server
                SmtpClient SmtpServer = new SmtpClient("mail.dustinkraft.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");

                SmtpServer.Send(mail);

                //redirect the user back to contact page
                return RedirectToAction("ThankYou", "ThankYou");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}