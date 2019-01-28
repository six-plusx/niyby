using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 浏览历史表
    /// </summary>
    public class Browse
    {
        /// <summary>
        /// 浏览id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 浏览内容
        /// </summary>
        public string BrowseContent { get; set; }

        /// <summary>
        /// 浏览标题
        /// </summary>
        public string BrowseTitle { get; set; }
    }
}
