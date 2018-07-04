using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    public class IndexImage:ModelBase
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        [Required]
        public string file { get; set; }

        /// <summary>
        /// 自定义名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language { get; set; }
    }
}
