using QLVT.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLVT.Controllers
{
    public class LoginController : Controller
    {
        private MasterDbCotext masterDb = new MasterDbCotext("MASTER");
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {
            string username = form["username"];
            string password = form["password"];
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Username and Password are required";
                return View();
            }

            var user = masterDb.accounts.FirstOrDefault(u => u.MaNV == decimal.Parse(username) && u.Password == password); ;
            if (user != null)
            {
                //Lay thong tin chi nhanh de luu vao session, phuc vu cho muc dich query theo chi nhanh
                var maCN=masterDb.employees.FirstOrDefault(emp => emp.MaNV == user.MaNV).MaCN;
                // Lưu thông tin người dùng vào session
                Session["UserId"] = user.MaNV;
                Session["MaCN"] = maCN;

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }
    }
}