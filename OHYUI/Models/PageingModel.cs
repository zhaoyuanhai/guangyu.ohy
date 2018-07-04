using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OHYUI.Models
{
    public class PageingModel
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Total * 1.0 / PageSize);
            }
        }

        public int Total { get; set; }
    }
}