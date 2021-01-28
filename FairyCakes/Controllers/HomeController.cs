using FairyCakes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FairyCakes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/cakes")]
        public IActionResult Cakes()
        {
            return View();
        }

        [HttpGet("/confirm")]
        public IActionResult ConfirmOrder()
        {
            ViewBag.TotalPrice = HttpContext.Request.Cookies["price"];
            ViewBag.CustomerName = HttpContext.Request.Cookies["name"];
            ViewBag.CustomisationString = HttpContext.Request.Cookies["custom"];
            ViewBag.Slice = HttpContext.Request.Cookies["slices"];
            ViewBag.Phone = HttpContext.Request.Cookies["phone"];
            ViewBag.Cake = HttpContext.Request.Cookies["cake"];
            ViewBag.PickupDay = HttpContext.Request.Cookies["pickup"];


            return View();
        }

        [HttpGet("/order")]
        public IActionResult Order()
        {
            var model = new OrderModel();

            model.Cake = "fruitCake";

            return View(model);
        }

        [HttpPost("/order")]
        public IActionResult Order(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Slice == "6")
                {
                    model.TotalPrice = model.TotalPrice + 20;
                } else if(model.Slice == "8")
                {
                    model.TotalPrice = model.TotalPrice + 28;
                } else if(model.Slice == "10")
                {
                    model.TotalPrice = model.TotalPrice + 35;
                }

                if(model.Customisation == true)
                {
                    model.TotalPrice = model.TotalPrice + 5;
                }
                var cakeName = "";
                foreach (var cake in model.Cakes)
                {
                    if(cake.Value == model.Cake)
                    {
                        cakeName = cake.Text;
                    }
                }
                Response.Cookies.Append("price", model.TotalPrice.ToString(), new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                Response.Cookies.Append("name", model.CustomerName, new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                Response.Cookies.Append("phone", model.Phone, new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                Response.Cookies.Append("cake", cakeName, new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                Response.Cookies.Append("slices", model.Slice + " slices", new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                if(model.CustomisationString != "" && model.CustomisationString != null)
                {
                    Response.Cookies.Append("custom", model.CustomisationString, new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                } else
                {
                    Response.Cookies.Append("custom", "Customisation has not been set", new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                }
                Response.Cookies.Append("pickup", model.PickupDay.ToString(), new CookieOptions() { Expires = DateTime.Now.AddMinutes(10), IsEssential = true });
                return RedirectToAction("ConfirmOrder", "Home");
            }
            
            return View(model);
        }
    }
}
