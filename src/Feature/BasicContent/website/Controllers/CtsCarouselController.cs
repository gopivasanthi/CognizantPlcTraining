using CognizantPlc.Feature.BasicContent.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CognizantPlc.Feature.BasicContent.Controllers
{
    public class CtsCarouselController : Controller
    {
        // GET: CtsCarousel
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            if (contextItem != null)
            {
                if (contextItem.HasChildren)
                {
                    var childCarouselItems = contextItem.Children
                                               .Select(x => new CarouselItem
                                               {
                                                   CarouselTitle = x?.Fields["PageHeroTitle"]?.Value ?? "[Hero Title Missing]",
                                                   CarouselDescription = x?.Fields["PageHeroDescription"]?.Value ?? "[Hero Description Missing]",
                                                   CarouselImage = GetImage(x, "PageHeroImage")
                                               });

                }
                else
                {
                    return View("EmptyCarousel");
                }
                
                return View();
            }
            else
            {
                return View("ErrorCarousel");
            }
        }

        private CarouselImage GetImage(Item item, string fieldName)
        {
            if (item.Fields[fieldName] != null)
            {
                ImageField imageField = item.Fields[fieldName];
                if (imageField != null)
                {
                    CarouselImage carouselImage = new CarouselImage
                    {
                        ImageUrl = MediaManager.GetMediaUrl(imageField.MediaItem),
                        ImageAlt = imageField.Alt ?? "[Alt Missing]",
                    };
                    return carouselImage;
                }
                else
                {
                    return new CarouselImage()
                    {
                        ImageAlt = "[Image Missing]",
                        ImageUrl = "[Image Missing]"
                    };
                }
            }
            else
            {
                return null;
            }
        }
    }
}