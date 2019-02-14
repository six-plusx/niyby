using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Six.Wx.IRepositoy.Zbs;
using Six.Wx.Model;
using Dapper;
using System.Data;
using System.Data.OracleClient;

namespace Six.Wx.Repositoy.Zbs
{
    /// <summary>
    /// 收货地址实现层
    /// </summary>
    public class ZAddressRepository : IZAddressRepository
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        //public static string connStr = ConfigurationManager.ConnectionStrings["conStr"].ToString();
        public static string connStr = ConfigHelper.conStr;

        /// <summary>
        /// 返回所有的收货地址
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Address> GetAllAddresses()
        {
            string sql = "select * from loc";
            using (IDbConnection conn = new OracleConnection(connStr))
            {
                var addreslist = conn.Query<Address>(sql);
                conn.Dispose();
                conn.Close();
                return addreslist;
            }
        }

        /// <summary>
        /// 返回一条的收货地址
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Address> GetOneAddresses(int id)
        {
            string sql = "select * from loc where id=" + id;
            using (IDbConnection conn = new OracleConnection(connStr))
            {
                var addreslist = conn.Query<Address>(sql);
                conn.Dispose();
                conn.Close();
                return addreslist;
            }
        }
    }
}
