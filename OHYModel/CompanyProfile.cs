using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    public class CompanyProfile : ModelBase
    {
        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [Required]
        public string ImaPath { get; set; }


        /// <summary>
        /// 内容 
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 内容来源分类 固定值（公司简介，联系方式）
        /// </summary>
        [Required]
        public ContentTypeEnum Type { get; set; }


        /// <summary>
        /// 公司名字
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        public string TellPhone { get; set; }


        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }


        /// <summary>
        /// 邮件
        /// </summary>
        public string Eamil { get; set; }

        /// <summary>
        /// 网站地址
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// 公司信息
        /// </summary>
        public string[] Note { get; set; }

    }
}
