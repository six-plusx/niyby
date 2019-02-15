using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Six.Wx.IRepositoy.Zbs;
using Six.Wx.Model;
using System.Web;

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


        /// <summary>
        /// 添加一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddAddresses")]
        public int AddAddresses()
        {
            var address = new Address();
            address.Area = HttpContext.Current.Request["area"];
            address.Loction = HttpContext.Current.Request["loction"];
            address.Consignee = HttpContext.Current.Request["consignee"];
            address.Photo = HttpContext.Current.Request["photo"];
            address.DefaultLoc = Convert.ToBoolean(HttpContext.Current.Request["defaultLoc"]) == true ? 1 : 0;

            int i = zAddressRepository.AddAddresses(address);
            return i;
        }
    }
}
