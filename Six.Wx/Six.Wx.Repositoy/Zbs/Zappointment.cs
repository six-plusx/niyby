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
using System.Data.SqlClient;

namespace Six.Wx.Repositoy.Zbs
{
    /// <summary>
    /// 已经预购的图书
    /// </summary>
    public class Zappointment : IZappointment
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Classification> GetClassifications()
        {
            string sql = "";
            //链接数据库
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                var classificationlist = conn.Query<Classification>(sql);
                return classificationlist;
            }
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Classification> GetClassifications(string name)
        {
            string sql = "";
            //链接数据库
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                var classificationlist = conn.Query<Classification>(sql);
                return classificationlist;
            }
        }
    }
}
