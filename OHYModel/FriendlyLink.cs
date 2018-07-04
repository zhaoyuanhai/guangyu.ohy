using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    public class FriendlyLink : ModelBase
    {
        /// <summary>
        /// Logo路径
        /// </summary>
        [Required]
        public string Path { get; set; }


        /// <summary>
        /// 公司链接地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language { get; set; }

    }
}
