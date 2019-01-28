using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 内容简介表
    /// </summary>
    public class Content
    {
        /// <summary>
        /// 内容简介id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 图书id
        /// </summary>
        public int BooksId { get; set; }
    }
}
