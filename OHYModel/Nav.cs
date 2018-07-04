using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHYModel
{
    public class Nav : ModelBase, IComparer<Nav>, IComparable
    {
        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language { get; set; }

        public int Compare(Nav x, Nav y)
        {
            return x.Sort - y.Sort;
        }

        public int CompareTo(object obj)
        {
            return this.Sort - (obj as Nav).Sort;
        }
    }
}
