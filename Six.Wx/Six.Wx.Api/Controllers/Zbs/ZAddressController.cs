using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Six.Wx.IRepositoy.Zbs;
using Six.Wx.Model;
using System.Web;
using Six.Wx.Common;
using Newtonsoft.Json;

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
        [RequestAuthorize]
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
        [RequestAuthorize]
        [HttpGet]
        [ActionName("GetAddressesByid")]
        public IEnumerable<Address> GetAddressesByid(int id)
        {
            var classificationlist = zAddressRepository.GetAddressesByid(id);
            return classificationlist;
        }

        /// <summary>
        /// 添加一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [RequestAuthorize]
        [HttpGet]
        [ActionName("Add")]
        public int Add()
        {
            var address = new Address();
            address.Area = HttpContext.Current.Request["area"];
            address.Loction = HttpContext.Current.Request["loction"];
            address.Consignee = HttpContext.Current.Request["consignee"];
            address.Photo = HttpContext.Current.Request["photo"];
            address.DefaultLoc = Convert.ToBoolean(HttpContext.Current.Request["defaultLoc"]) == true ? 1 : 0;

            int i = zAddressRepository.Add(address);
            return i;
        }

        /// <summary>
        /// 修改一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [RequestAuthorize]
        [HttpGet]
        [ActionName("Update")]
        public int Update()
        {
            var address = new Address();
            address.Id = Convert.ToInt32(HttpContext.Current.Request["id"]);
            address.Area = HttpContext.Current.Request["area"];
            address.Loction = HttpContext.Current.Request["loction"];
            address.Consignee = HttpContext.Current.Request["consignee"];
            address.Photo = HttpContext.Current.Request["photo"];
            address.DefaultLoc = Convert.ToBoolean(HttpContext.Current.Request["defaultLoc"]) == true ? 1 : 0;

            int i = zAddressRepository.Update(address);
            return i;
        }

        /// <summary>
        /// 删除一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [RequestAuthorize]
        [HttpGet]
        [ActionName("Delete")]
        public int Delete(int id)
        {
            int i = zAddressRepository.Delete(id);
            return i;
        }

        /// <summary>
        /// 手机端登录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public ClientInfo Login(string code)
        {
            var client = Logins(code);
            return client;
        }

        /// <summary>
        /// 获取微信会话密钥
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ClientInfo Logins(string code)
        {
            ClientInfo clientinfo = new ClientInfo();
            HttpClient httpclient = new HttpClient();

            //登陆公众平台 开发->基本配置中的开发者ID(AppID)和 开发者密码(AppSecret)
            string appid = "wxa9cc17df60833c42";//开发者ID
            string secret = "0d4c74bf0d8ef24cf7fcadf3d4b0a6be";//开发者秘钥
            httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = httpclient.PostAsync("https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + code.ToString() + "&grant_type=authorization_code", null).Result;
            var result = "";
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            httpclient.Dispose();
            var results = JsonConvert.DeserializeObject<ClientInfo>(result);
            clientinfo.OpenId = results.OpenId;//用户唯一标识
            clientinfo.session_key = results.session_key;//密钥
                                                         //var client = uc.ClientInfo.Where(m => m.OpenId.Equals(clientinfo.OpenId)).FirstOrDefault();//判断是否为已注册用户
                                                         //if (client == null)
                                                         //{
                                                         //    uc.ClientInfo.Add(clientinfo);
                                                         //    uc.SaveChanges();
                                                         //}

            var tmpKey = clientinfo.session_key;
            var tmpVal = clientinfo;
            RedisHelper.Set<ClientInfo>(tmpKey, tmpVal, DateTime.Now.AddHours(10));
            var tmpClient = RedisHelper.Get<ClientInfo>(tmpKey);
            return clientinfo;
        }
    }
}
