using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Six.Wx.IRepositoy.Dq;
using Six.Wx.Model;

namespace Six.Wx.Api.Controllers.SQ
{
    public class SappointmentController : ApiController
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public ISappointmentRepository sappointment { get; set; }

        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetBooksSelects")]
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            var classificationlist = sappointment.GetBooksSelects();
            return classificationlist;
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetSumBooksSelects")]
        public IEnumerable<BooksSelect> GetSumBooksSelects(string names)
        {
            var classificationlist = sappointment.GetSumBooksSelects(names);
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
            var classificationlist = sappointment.GetOneBooksSelects(id);
            return classificationlist;
        }
    }
}
