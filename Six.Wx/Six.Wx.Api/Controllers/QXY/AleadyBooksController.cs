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
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            var bookslist = aleadyBooksRepository.GetBooksSelects();
            return bookslist;
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BooksSelect> GetSumBooksSelects(string names)
        {
            var bookslist = aleadyBooksRepository.GetSumBooksSelects(names);
            return bookslist;
        }

        /// <summary>
        /// 查询一条图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BooksSelect> GetOneBooksSelects(int id)
        {
            var bookslist = aleadyBooksRepository.GetOneBooksSelects(id);
            return bookslist;
        }

    }
}
