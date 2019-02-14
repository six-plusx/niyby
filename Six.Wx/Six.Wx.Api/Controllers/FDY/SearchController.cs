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
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            var books = searchs.GetBooksSelects();
            return books;
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetSumBooksSelects")]
        public IEnumerable<BooksSelect> GetSumBooksSelects(string name, int typeid)
        {
            var classificationlist = searchs.GetSumBooksSelects(names,typeid);
            return classificationlist;
        }

        /// <summary>
        /// 查询一条图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetOneBooksSelects")]
        public IEnumerable<BooksSelect> GetOneBooksSelects(int id)
        {
            var classificationlist = searchs.GetOneBooksSelects(id);
            return classificationlist;
        }
    }
}
