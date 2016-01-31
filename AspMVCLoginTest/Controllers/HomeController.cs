using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMVCLoginTest.Controllers
{
    /// <summary>
    /// Interaction Logic for HomeController.
    /// </summary>
    public class HomeController : Controller
    {
        #region Fields

        // Connection to DataAccessLayer.
        private Layers.DataAccessLayer dataAccessLayer = new Layers.DataAccessLayer();

        #endregion Fields

        #region Methods

        // GET: Home
        /// <summary>
        /// Pre Index View.
        /// </summary>
        /// <returns>The Index View.</returns>
        public ActionResult Index()
        {
            Session["UserId"] = 0;
            Session["UserName"] = string.Empty;
            Session["UserEmail"] = string.Empty;
            Session["UserRegistrationDate"] = DateTime.MinValue;
            Session["UserIsDeleted"] = true;

            return View();
        }

        /// <summary>
        /// Pre Login View.
        /// </summary>
        /// <returns>The Login View.</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post Login View.
        /// </summary>
        /// <param name="formCollection">The values from the form.</param>
        /// <returns>The Login or the Loggedin View.</returns>
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                List<Models.User> users = dataAccessLayer.FindUserByEmailAndPassword(formCollection["userEmail"], formCollection["userPassword"]);

                if (users != null && users.Count == 1)
                {
                    Session["UserId"] = users[0].Id;
                    Session["UserName"] = users[0].Name;
                    Session["UserEmail"] = users[0].Email;
                    Session["UserRegistrationDate"] = users[0].RegistrationDate;
                    Session["UserIsDeleted"] = users[0].IsDeleted;

                    return RedirectToAction("LoggedIn");
                }

                return View();
            }

            return View();
        }

        /// <summary>
        /// Pre Users View.
        /// </summary>
        /// <returns>The Users View.</returns>
        public ActionResult Users()
        {
            if (Session != null && Session["UserId"] != null && Session["UserName"] != null && Session["UserEmail"] != null &&
                Session["UserRegistrationDate"] != null && Session["UserIsDeleted"] != null &&
                (int)Session["UserId"] > 0 && !string.IsNullOrEmpty((string)Session["UserName"]) &&
                !string.IsNullOrEmpty((string)Session["UserEmail"]) && (DateTime)Session["UserRegistrationDate"] != DateTime.MinValue &&
                (bool)Session["UserIsDeleted"] == false)
            {
                List<Models.User> users = dataAccessLayer.ListUsers();
                ViewBag.Users = users;

                return View();
            }

            return RedirectToAction("Login");
        }

        /// <summary>
        /// Pre Registration View.
        /// </summary>
        /// <returns>The Registration View.</returns>
        public ActionResult Registration()
        {
            return View();
        }

        /// <summary>
        /// Post Registration View.
        /// </summary>
        /// <param name="formCollection">The values from the form.</param>
        /// <returns>The Registration or the Index View.</returns>
        [HttpPost]
        public ActionResult Registration(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                if (dataAccessLayer.AddUser(formCollection["userName"], formCollection["userEmail"], formCollection["userPassword"]))
                {
                    return RedirectToAction("Index");
                }

                return View();
            }

            return View();
        }

        /// <summary>
        /// Pre LoggedIn View.
        /// </summary>
        /// <param name="input">The values for the logged in user.</param>
        /// <returns>The Loggedin or the Index View.</returns>
        public ActionResult LoggedIn()
        {
            if (Session != null && Session["UserId"] != null && Session["UserName"] != null && Session["UserEmail"] != null && 
                Session["UserRegistrationDate"] != null && Session["UserIsDeleted"] != null && 
                (int)Session["UserId"] > 0 && !string.IsNullOrEmpty((string)Session["UserName"]) &&
                !string.IsNullOrEmpty((string)Session["UserEmail"]) && (DateTime)Session["UserRegistrationDate"] != DateTime.MinValue &&
                (bool)Session["UserIsDeleted"] == false)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        #endregion Methods
    }
}