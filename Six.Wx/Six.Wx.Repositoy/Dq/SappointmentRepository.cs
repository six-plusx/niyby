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
        /// 查询所有图书
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetAllBook()
        {
            string sql = "select *from booksselect b left join picture p on b.id=p.booksselectid";
            using (IDbConnection conn=new OracleConnection(ConfigHelper.ConnString))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                conn.Dispose();
                conn.Close();
                return booksSelectlist;
            }
        }

        /// <summary>
        /// 根据ID图书信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBookById(int id)
        {
            string sql = $"select * from booksselect b left join picture p on b.id=p.booksselect.id where b.id='{id}'";
            using (IDbConnection conn=new OracleConnection(ConfigHelper.ConnString))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return booksSelectlist;
            }
        }

        /// <summary>
        /// 根据姓名和id查询图书
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBookByName(string name,int typeid)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where BOOKSNAME like '%{name}%' and ClassifyId={typeid}";
            using (IDbConnection conn=new OracleConnection(ConfigHelper.ConnString))
            {
                var booksSelectlist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return booksSelectlist;
            }
        }
    }
}
