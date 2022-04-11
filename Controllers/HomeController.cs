using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission_13.Models;

namespace Mission_13.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext repo { get; set; }

        public HomeController(BowlingDbContext temp)
        {
            repo = temp;
        }

        //display bowler data
        public IActionResult Index()
        {
            var stuff = repo.Bowlers.ToList();
            return View(stuff);
        }


        // get and post constructors for editing movies
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Bowlers = repo.Bowlers.ToList();

            var bowl = repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("Form", bowl);
        }

        //edit crash post and update
        [HttpPost]
        public IActionResult Edit(Bowler bowler)
        {
            repo.Update(bowler);
            repo.SaveChanges();

            return View("Admin");
        }

        // get and post constructors for deleting movies
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowl = repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(bowl);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            repo.Bowlers.Remove(bowler);
            repo.SaveChanges();

            return View("Admin");
        }
    }

}
