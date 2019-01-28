using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 热门搜索
    /// </summary>
    public class HotSearch
    {
        /// <summary>
        /// 热门id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 搜索标题
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// 搜索分类
        /// </summary>
        public string Classify { get; set; }
    }
}
