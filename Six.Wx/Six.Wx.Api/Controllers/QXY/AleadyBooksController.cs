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
    public class AleadyBooksController : ApiController
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public IAleadyBooksRepository aleadyBooksRepository { get; set; }

        /// <summary>
        /// 添加图书
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int AddBooks(BooksSelect booksSelect)
        {
            var books = aleadyBooksRepository.AddBooks(booksSelect);
            return books;
        }

        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BooksSelect> GetBooksSelectlist()
        {
            var bookslist = aleadyBooksRepository.GetBooksSelectlist();
            return bookslist;
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BooksSelect> GetBooksSelects(string names)
        {
            var bookslist = aleadyBooksRepository.GetBooksSelects(names);
            return bookslist;
        }

        /// <summary>
        /// 查询一条图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BooksSelect> GetBooksById(int id)
        {
            var bookslist = aleadyBooksRepository.GetBooksById(id);
            return bookslist;
        }

    }
}
