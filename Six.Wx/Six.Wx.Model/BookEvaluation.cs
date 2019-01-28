using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 图书评价表
    /// </summary>
    public class BookEvaluation
    {
        /// <summary>
        /// 图书评价id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 评价内容
        /// </summary>
        public string Evaluate { get; set; }

        /// <summary>
        /// 图书id
        /// </summary>
        public int BooksId { get; set; }

        /// <summary>
        /// 图书状态
        /// </summary>
        public int BooksState { get; set; }
    }
}
