using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 日志表
    /// </summary>
    public class TheLog
    {
        /// <summary>
        /// 日志id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string Timer { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Admin { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        public string operaContent { get; set; }
    }
}
