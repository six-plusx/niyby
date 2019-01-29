using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class Classification
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 游戏类
        /// </summary>
        public string Game { get; set; }

        /// <summary>
        /// 书法类
        /// </summary>
        public string Calligraphy { get; set; }

        /// <summary>
        /// 动漫类
        /// </summary>
        public string Cartoon { get; set; }

        /// <summary>
        /// 言情类
        /// </summary>
        public string Erotica { get; set; }

        /// <summary>
        /// 惊悚类
        /// </summary>
        public string Panic { get; set; }

        /// <summary>
        /// 动作类
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 爱国类
        /// </summary>
        public string Patriotic { get; set; }

        /// <summary>
        /// 冒险类
        /// </summary>
        public string Side { get; set; }

        /// <summary>
        /// 喜剧类
        /// </summary>
        public string Comedy { get; set; }

        /// <summary>
        /// 文艺类
        /// </summary>
        public string Arts { get; set; }
    }
}
