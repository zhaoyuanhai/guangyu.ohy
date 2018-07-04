using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    //新闻中心
    public class PressCenter : ModelBase
    {
        /// <summary>
        /// 新闻标题
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 新闻内容
        /// </summary>
        [Required]
        public string Content { get; set; }

        public string Intro { get; set; }

        /// <summary>
        /// 类型(区分企业动态/行业资讯)
        /// </summary>
        [Required]
        public ContentTypeEnum Type { get; set; }

        public LanguageEnum Language { get; set; }
    }
}
