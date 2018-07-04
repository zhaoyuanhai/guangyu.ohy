using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    /// <summary>
    /// 产品中心
    /// </summary>
    public class Product : ModelBase
    {
        /// <summary>
        /// 封面路径
        /// </summary>
        [Required]
        public string Cover { get; set; }
        /// <summary>
        /// pdf路径
        /// </summary>
        [Required]
        public string PdfPath { get; set; }
        /// <summary>
        /// 图片名字
        /// </summary>
        public string Name { get; set; }
        [Required]
        public int PdfCount { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language { get; set; }
    }
}
