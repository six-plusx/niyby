using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;//链接字符串所需要的命名空间
using Six.Wx.IRepositoy.Zbs;
using Six.Wx.Model;
using Dapper;
using System.Data;
using System.Data.OracleClient;
using Six.Wx.Common;
using System.Net.Http;
using Newtonsoft.Json;

namespace Six.Wx.Repositoy.Zbs
{
    /// <summary>
    /// 已经预购的图书
    /// </summary>
    public class ZappointmentRepository : IZappointmentRepository
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        //public static string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;


        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetAllBooks()
        {
            //string sql = "select * from BooksSelect b left join Picture p on b.id = p.booksselectid where b.State=0";
            string sql = "select * from BooksSelect b left join Picture p on b.id = p.booksselectid";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                conn.Dispose();
                conn.Close();
                return booksSelectlist;
            }
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBooksByName(string name, int typeid)
        {
            //string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where b.State=0 and BOOKSNAME like '%{name}%' and ClassifyId={typeid}";
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where BOOKSNAME like '%{name}%' and ClassifyId={typeid}";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                conn.Dispose();
                conn.Close();
                return booksSelectlist;
            }
        }

        /// <summary>
        /// 查询一条的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBooksById(int id)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid left join bookscontent bc on b.id=bc.booksselectid left join booksevaluate be on b.id=be.booksselectid where b.id ='{id}'";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                conn.Dispose();
                conn.Close();
                return booksSelectlist;
            }
        }

        /// <summary>
        /// 获取微信会话密钥
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //public Personal Logins(string code)
        //{
        //    using (UnityContext uc = new UnityContext())
        //    {
        //        Personal personal = new Personal();
        //        HttpClient httpclient = new HttpClient();

        //        //登陆公众平台 开发->基本配置中的开发者ID(AppID)和 开发者密码(AppSecret)
        //        string appid = "wx9cfd1269436269a8";//开发者ID
        //        string secret = "4b62a45558a4aa06e717c73a2b3229ef";//开发者秘钥
        //        httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //        HttpResponseMessage response = httpclient.PostAsync("https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + code.ToString() + "&grant_type=authorization_code", null).Result;
        //        var result = "";
        //        if (response.IsSuccessStatusCode)
        //        {
        //            result = response.Content.ReadAsStringAsync().Result;
        //        }
        //        httpclient.Dispose();
        //        var results = JsonConvert.DeserializeObject<Personal>(result);
        //        personal.OpenId = results.OpenId;//用户唯一标识
        //        personal.session_key = results.session_key;//密钥
        //        var client = uc.Personal.Where(m => m.OpenId.Equals(personal.OpenId)).FirstOrDefault();//判断是否为已注册用户
        //        if (client == null)
        //        {
        //            uc.Personal.Add(personal);
        //            uc.SaveChanges();
        //        }
        //        RedisHelper.Set<Personal>(personal.session_key, personal, DateTime.Now.AddHours(10));
        //        return personal;
        //    }
        //}
    }
}
