using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;//链接字符串所需要的命名空间
using Six.Wx.IRepositoy.Dq;
using Six.Wx.Model;
using Dapper;
using System.Data;
using System.Data.OracleClient;

namespace Six.Wx.Repositoy.Dq
{
    /// <summary>
    /// 已购图书
    /// </summary>
    public class SappointmentRepository:ISappointmentRepository
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 查询所有的图书信息
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

        /// <summary>
        /// 查询一条图书的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetOneBooksSelects(int id)
        {
            string sql = $"select * from BooksSelect where id ='{id}'";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(connStr))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                return booksSelectlist;
            }
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetSumBooksSelects(string name)
        {
            string sql = $"select * from BooksSelect where BOOKSNAME like '%{name}%'";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(connStr))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                return booksSelectlist;
            }
        }
    }
}
