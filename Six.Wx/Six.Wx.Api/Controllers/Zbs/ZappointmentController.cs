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
        public IZappointment zappointment { get; set; }

        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetClassifications")]
        public IEnumerable<Classification> GetClassifications()
        {
            var classificationlist = zappointment.GetClassifications();
            return classificationlist;
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetClassifications")]
        public IEnumerable<Classification> GetClassifications(string name)
        {
            var classificationlist = zappointment.GetClassifications(name);
            return classificationlist;
        }
    }
}
