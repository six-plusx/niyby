using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Six.Wx.IRepositoy.Zbs;
using Six.Wx.Model;

namespace Six.Wx.Api.Controllers.Zbs
{
    public class ZappointmentController : ApiController
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public IZappointmentRepository zappointment { get; set; }

        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllBooks")]
        public IEnumerable<BooksSelect> GetAllBooks()
        {
            var classificationlist = zappointment.GetAllBooks();
            return classificationlist;
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetBooksByName")]
        public IEnumerable<BooksSelect> GetBooksByName(string names, int typeid)
        {
            var classificationlist = zappointment.GetBooksByName(names, typeid);
            return classificationlist;
        }

        /// <summary>
        /// 查询一条图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetBooksById")]
        public IEnumerable<BooksSelect> GetBooksById(int id)
        {
            var classificationlist = zappointment.GetBooksById(id);
            return classificationlist;
        }
    }
}
