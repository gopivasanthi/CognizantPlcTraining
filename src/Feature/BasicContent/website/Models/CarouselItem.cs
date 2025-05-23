using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CognizantPlc.Feature.BasicContent.Models
{
    public class CarouselItem
    {
        public string CarouselTitle { get; set; }

        private string _CarouselDescription;
        public string CarouselDescription
        {
            get
            {
                if (string.IsNullOrEmpty(_CarouselDescription))
                {
                    return string.Empty;
                }
                else
                {
                    if (_CarouselDescription.Length > 15)
                    {
                        return $"{_CarouselDescription.Substring(0, 15)}...";
                    }
                    else
                        return _CarouselDescription;
                }
            }
            set
            {
                _CarouselDescription = value;
            }
        }
        public CarouselImage CarouselImage { get; set; }
        public string CarouselItemUrl { get; set; }

    }
}