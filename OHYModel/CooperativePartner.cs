using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    /// <summary>
    /// 合作伙伴
    /// </summary>
    public class CooperativePartner : ModelBase
    {
        /// <summary>
        /// 封面路径
        /// </summary>
       [Required]
        public string ImgPath { get; set; }
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
