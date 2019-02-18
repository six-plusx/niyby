using Six.Wx.IRepositoy.Qxy;
using Six.Wx.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Six.Wx.Repositoy.Qxy
{
    /// <summary>
    /// 已录入图书实现类
    /// </summary>
    public class AleadyBooksRepository : IAleadyBooksRepository
    {
        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        public static string strConn = ConfigHelper.conStr;


        /// <summary>
        /// 显示图书信息列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            string sql = "select * from BooksSelect";
            using (IDbConnection conn = new OracleConnection(strConn))
            {
                var bookslist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return bookslist;
            }
        }

        /// <summary>
        /// 按姓名查询图书
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<BooksSelect>GetSumBooksSelects(string name)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where BOOKSNAME like '%{name}%'";
            using (IDbConnection conn = new OracleConnection(strConn))
            {
                var bookslist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return bookslist;
            }
        }

        public IEnumerable<BooksSelect> GetOneBooksSelects(int id)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where b.id ='{id}'";
            using(IDbConnection conn=new OracleConnection(strConn))
            {
                var bookslist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return bookslist;
            }
        }

               
    }
}
