using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OHYModel;

namespace OHYUI.Models
{
    public class IndexModel
    {
        public List<IndexImage> RightImageList { get; set; }

        public List<HomeText> HomeText { get; set; }

        public List<PressCenter> NewsList { get; set; }
    }
}