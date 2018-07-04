using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    //解决方案
   public class Solution:ModelBase
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        [Required]
        public string ImgPath { get; set; }
        /// <summary>
        /// pdf路径
        /// </summary>
        public string pdfPath { get; set; }
        /// <summary>
        /// 图片名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language { get; set; }

    }
}
