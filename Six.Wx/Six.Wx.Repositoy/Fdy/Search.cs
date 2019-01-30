using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using Six.Wx.Model;
using Dapper;
using Six.Wx.IRepositoy.Fdy;
using System.Data;
using System.Data.OracleClient;

namespace Six.Wx.Repositoy.Fdy
{
    public class Search : ISearch
    {
        /// <summary>
        /// 连接字符串语句
        /// </summary>
        public static string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 获取所有图书的信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            string sql = "select * from BooksSelect";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(connStr))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                return booksSelectlist;
            }
        }
    }
}
