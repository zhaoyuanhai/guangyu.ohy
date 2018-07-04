using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    public class Customer : ModelBase
    {
        /// <summary>
        /// 尊称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string TelePhone { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 需求
        /// </summary>
        public string requirement { get; set; }

    }
}
