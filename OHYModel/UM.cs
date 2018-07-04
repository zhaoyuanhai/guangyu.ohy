using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
   public class UM:ModelBase
    {
        /// <summary>
        /// 用户名字
        /// </summary>
        [Required(ErrorMessage = "请输入用户名")]
        [Display(Name = "用户名")]
        [StringLength(20, ErrorMessage = "{0}在{2}位至{1}位之间", MinimumLength = 1)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "{0}在{2}位至{1}位之间", MinimumLength = 6)]
        public string PassWord { get; set; }
    }
}
