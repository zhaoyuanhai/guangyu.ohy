using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace OHYModel
{
    //业绩展示
    public class PerformancePresentation : ModelBase
    {
        /// <summary>
        /// 项目时间
        /// </summary>
        [DisplayName("项目时间")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string EntryTime { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [DisplayName("项目名称")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string EntryName { get; set; }

        /// <summary>
        /// 公司名字
        /// </summary>
        [DisplayName("公司名字")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 语言分类
        /// </summary>
        public LanguageEnum Language { get; set; }

    }
}
