using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 图片表
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// 图片id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string PictureName { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicturePath { get; set; }

        /// <summary>
        /// 图书id
        /// </summary>
        public int BooksId { get; set; }

    }
}
