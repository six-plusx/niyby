using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Six.Wx.IRepositoy.Fdy;
using Six.Wx.Model;

namespace Six.Wx.Api.Controllers.FDY
{
    public class SearchController : ApiController
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public ISearchRepository searchs { get; set; }

        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetBooksSelects")]
        public IEnumerable<BooksSelect> GetAllBooks()
        {
            var bookLists = searchs.GetAllBooks();
            return bookLists;
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetSumBooksSelects")]
        public IEnumerable<BooksSelect> GetBookByName(string name, int typeid)
        {
            var bookNames = searchs.GetBookByName(name,typeid);
            return bookNames;
        }

        /// <summary>
        /// 查询一条图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetOneBooksSelects")]
        public IEnumerable<BooksSelect> GetBookByID(int id)
        {
            var bookID = searchs.GetBookByID(id);
            return bookID;
        }
    }
}
