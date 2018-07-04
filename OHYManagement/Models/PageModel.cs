using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OHYManagement.Models
{
    public class PageModel
    {
        private int pageIndex = 1;
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
            }
        }
        private int pageSize = 10;
        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }
        public long Count {get; set; }
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling(Count*1.0 / PageSize);
            }
        }
        public string Url { get; set; }

        
    }
}