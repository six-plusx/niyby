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
        public string ClassifyName { get; set; }        
    }
}
