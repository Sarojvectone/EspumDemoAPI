using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EspumDemoAPI.Models
{
    public class productlstModel
    {
        public long ean { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
    }
}