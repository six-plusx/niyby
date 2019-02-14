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
    public class ZAddressController : ApiController
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public IZAddressRepository zAddressRepository { get; set; }

        /// <summary>
        /// 查询所有的地址
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllAddresses")]
        public IEnumerable<Address> GetAllAddresses()
        {
            var classificationlist = zAddressRepository.GetAllAddresses();
            return classificationlist;
        }

        /// <summary>
        /// 查询一条地址
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetOneAddresses")]
        public IEnumerable<Address> GetOneAddresses(int id)
        {
            var classificationlist = zAddressRepository.GetOneAddresses(id);
            return classificationlist;
        }
    }
}
