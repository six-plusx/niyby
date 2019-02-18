using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;//链接字符串所需要的命名空间
using Six.Wx.IRepositoy.Fdy;
using Six.Wx.Model;
using Dapper;
using System.Data;
using System.Data.OracleClient;

namespace Six.Wx.Repositoy.Fdy
{
    public class SearchRepository : ISearchRepository
    {
        /// <summary>
        /// 连接字符串语句
        /// </summary>
        //public static string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        /// <summary>
        /// 获取所有的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            string sql = "select * from BooksSelect b left join Picture p on b.id = p.booksselectid";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var bookLists = conn.Query<BooksSelect>(sql);
                return bookLists;
            }
        }

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetSumBooksSelects(string name, int typeid)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where BOOKSNAME like '%{name}%' and ClassifyId={typeid}";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var bookNames = conn.Query<BooksSelect>(sql);
                return bookNames;
            }
        }

        /// <summary>
        /// 查询一条的图书信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetOneBooksSelects(int id)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where b.id ='{id}'";
            //链接数据库
            using (IDbConnection conn = new OracleConnection(connStr))
            {
                var bookID = conn.Query<BooksSelect>(sql);
                return bookID;
            }
        }
    }
}
