﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 图书管理查询
    /// </summary>
    public class BooksSelect
    {
        /// <summary>
        /// 图书id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 图书名称
        /// </summary>
        public string BooksName { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 出版信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 可借数量
        /// </summary>
        public string LendNum { get; set; }

        /// <summary>
        /// 录入数量
        /// </summary>
        public string EnterNum { get; set; }

        /// <summary>
        /// 图书状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 图书内容
        /// </summary>
        public string BooksContent { get; set; }

        /// <summary>
        /// 作者简介
        /// </summary>
        public string AuthorIntro { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        public string Catalogue { get; set; }

        /// <summary>
        /// 图片id
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string PictureName { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicturePath { get; set; }

        /// <summary>
        /// 类别id
        /// </summary>
        public int ClassifyId { get; set; }

        /// <summary>
        /// 评价内容
        /// </summary>
        public string Evaluate { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
