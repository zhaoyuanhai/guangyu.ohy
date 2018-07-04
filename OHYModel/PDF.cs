using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    public class PDF : ModelBase
    {
        public string Title
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }
        [Required]
        public string AttachmentPath
        {
            get;
            set;
        }
        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language { get; set; }
    }

}
