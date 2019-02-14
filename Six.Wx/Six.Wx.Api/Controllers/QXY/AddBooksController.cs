using Six.Wx.IRepositoy.Qxy;
using Six.Wx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Six.Wx.Api.Controllers.QXY
{
    public class AddBooksController : ApiController
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public IAddBooksRepository addBooksRepository { get; set; }

        /// <summary>
        /// 添加图书
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int AddBooks(BooksSelect booksSelect)
        {
            var books = addBooksRepository.AddBooks(booksSelect);
            return books;
        }

        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            var bookslist = addBooksRepository.GetBooksSelects();
            return bookslist;
        }

    }
}
