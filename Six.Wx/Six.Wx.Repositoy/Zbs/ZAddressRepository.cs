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
using Six.Wx.Common;

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

        /// <summary>
        /// 返回所有的收货地址
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Address> GetAllAddresses()
        {
            string sql = "select * from loc";
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var addreslist = conn.Query<Address>(sql);
                conn.Close();
                return addreslist;
            }
        }

        /// <summary>
        /// 返回一条的收货地址
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Address> GetAddressesByid(int id)
        {
            string sql = "select * from loc where id=" + id;
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var addreslist = conn.Query<Address>(sql);
                conn.Close();
                return addreslist;
            }
        }

        /// <summary>
        /// 添加一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Add(Address address)
        {
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                string sql = "";
                int i = 0;
                if (address.DefaultLoc == 1)//如果设置为默认的,先把别的都给改成非默认
                {
                    sql = "select count(id) from loc where defaultloc = 1";//更改所有
                    i = Convert.ToInt32(conn.ExecuteScalar(sql));
                    if (i > 0)
                    {
                        //sql = "update loc set defaultloc=0 where id = (select id from loc where defaultloc=1)";
                        sql = "update loc set defaultloc=0";//更改所有
                        conn.Execute(sql);
                    }
                }
                sql = $"insert into loc(consignee,area,photo,loction，DefaultLoc) values('{address.Consignee}','{address.Area}','{address.Photo}','{address.Loction}','{address.DefaultLoc}')";
                i = conn.Execute(sql);
                conn.Close();
                return i;
            }
        }

        /// <summary>
        /// 修改一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Update(Address address)
        {
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                string sql = "";
                int i = 0;
                if (address.DefaultLoc == 1)//如果设置为默认的,先把别的都给改成非默认
                {
                    sql = "select count(id) from loc where defaultloc = 1";//更改所有
                    i = Convert.ToInt32(conn.ExecuteScalar(sql));
                    if (i > 0)
                    {
                        //sql = "update loc set defaultloc=0 where id = (select id from loc where defaultloc=1)";
                        sql = "update loc set defaultloc=0";//更改所有
                        conn.Execute(sql);
                    }
                }
                sql = $"update loc set consignee='{address.Consignee}',area='{address.Area}',photo='{address.Photo}',loction='{address.Loction}',DefaultLoc='{address.DefaultLoc}' where id='{address.Id}'";
                i = conn.Execute(sql);
                conn.Close();
                return i;
            }
        }

        /// <summary>
        /// 删除一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                string sql = $"delete from loc where id='{id}'";
                int i = conn.Execute(sql);
                conn.Close();
                return i;
            }
        }
    }
}
