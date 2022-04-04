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
        private BowlingDbContext _repo { get; set; }

        public HomeController(BowlingDbContext temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Bowlers
                .ToList();

            return View(blah);
        }


        // get and post constructors for editing movies
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Bowlers = _repo.Bowlers.ToList();

            var bowl = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("Form", bowl);
        }

        [HttpPost]
        public IActionResult Edit(Bowler bowler)
        {
            _repo.Update(bowler);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }

        // get and post constructors for deleting movies
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowl = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(bowl);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            _repo.Bowlers.Remove(bowler);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
