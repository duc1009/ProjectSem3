﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Ui.Controllers
{
    public class PictureAndCheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpLoadAndCheckOut()
        {
            return View();
        }
    }
}