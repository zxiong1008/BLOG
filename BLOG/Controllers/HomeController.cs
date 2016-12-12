using BLOG.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLOG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FiveNumbers()
        {
            //var model = new NumsViewModel();
            return View();
        }
        [HttpPost] //posting the model
        public ActionResult FiveNumbers(FiveNumbersViewModel FiveNumModel)
        {
            FiveNumModel.Calculate();
            return View(FiveNumModel);
        }
        public ActionResult Factorial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Factorial(FactorialViewModel FactModel)
        {
            FactModel.CalculateFact();
            return View(FactModel);
        }
        //fizzbuzz controller
        public ActionResult FizzBuzz()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FizzBuzz(FizzBuzzViewModel FizzModel)
        {
            FizzModel.GetFizzBuzz();
            return View(FizzModel);
        }
        //palindrome controller
        public ActionResult Palindrome()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Palindrome(PalindromeViewModels PalModel)
        {
            PalModel.CheckPalindrome();
            return View(PalModel);
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Portfolio()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[controller]get action -> contact -> [controller]post action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact([Bind(Include = "Id,firstname, lastname,Email,Message,Phone")] Contact contact) 
        {
            contact.Created = DateTime.Now;
            var newContact = contact.firstname + " " + contact.lastname;

            var svc = new EmailService();
            //email service is from the IdentityConfig.cs file from App_Start
            var msg = new IdentityMessage();
            //email service is from the IdentityConfig.cs file from App_Start
            msg.Subject = "Zeng Contact from Portolio Site";
            msg.Body = "<br/>" + "You have received a request to contact from "
                + newContact + " (" + contact.email + ")." + "<br/><br/>"
                + "With the following message:" + "<br/>"
                + contact.message;

            await svc.SendAsync(msg);

            return View(contact);
        }
    }
}