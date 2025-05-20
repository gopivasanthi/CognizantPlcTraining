using CognizantPlc.Feature.Navigation.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CognizantPlc.Feature.Navigation.Controllers
{
    public class CtsNavigationController : Controller
    {
        // GET: CtsNavigation
        public ActionResult Header()
        {
            //fetch the datasource item

            var datasourceItem = RenderingContext.Current.ContextItem;

            if (datasourceItem != null)
            {
                MultilistField headerNavigationItems = datasourceItem.Fields["HeaderNavigationItems"];
                NavigationItems headerNavigations = new NavigationItems
                {
                    Navigations = new List<NavigationItem>()
                };
                if (headerNavigationItems != null)
                {
                    //get the field from the datasource > HeaderNavigationItems
                    headerNavigations.Navigations = headerNavigationItems
                                                        .GetItems()
                                                        .Where(x => x.TemplateName == "DefaultContentPage")
                                                        .Select(x => new NavigationItem
                                                        {
                                                            NavigationItemTitle = x?.Fields["PageHeroTitle"]?.Value ?? "Page Hero Title Missing",
                                                            NavigationItemUrl = LinkManager.GetItemUrl(x),
                                                        }).ToList();

                    var homepageNavigationItems = headerNavigationItems
                                                        .GetItems()
                                                        .Where(x => x.TemplateName == "HomePage")
                                                        .Select(x => new NavigationItem
                                                        {
                                                            NavigationItemTitle = x?.Fields["HomeTitle"]?.Value ?? "Home Title Missing",
                                                            NavigationItemUrl = LinkManager.GetItemUrl(x),
                                                        }).ToList();

                    headerNavigations.Navigations.AddRange(homepageNavigationItems);

                }
                return View(headerNavigations);
            }
            else
            {
                return View("ErrorNavigation");
            }
        }
    }
}