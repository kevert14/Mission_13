using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission_13.Models;

namespace Mission_13.Components
{
    public class FilterViewComponent : ViewComponent
    {
        private BowlingDbContext context { get; set; }



        public FilterViewComponent(BowlingDbContext temp)
        {
            context = temp;
        }

        // function to grab the distinct different categories to display on the home page
        public IViewComponentResult Invoke()
        {

            //grab team names 
            ViewBag.SelectedType = RouteData?.Values["TeamName"];
            var counties = context.Teams.Select(x => x.TeamName).OrderBy(x => x);

            return View(counties);
        }
    }
}
