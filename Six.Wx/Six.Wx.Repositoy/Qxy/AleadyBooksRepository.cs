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
        /// 添加图书
        /// </summary>
        /// <returns></returns>
        public int AddBooks(BooksSelect booksSelect)
        {
            string sql = string.Format("insert into BooksSelect(BooksName,Author,Price,Message,EnterNum,Catalogue，State)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", booksSelect.BooksName, booksSelect.Author, booksSelect.Price, booksSelect.Message, booksSelect.EnterNum, booksSelect.Catalogue, booksSelect.State);
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var addbooks = conn.Execute(sql);
                conn.Close();
                return addbooks;
            }
        }

        /// <summary>
        /// 显示图书信息列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBooksSelectlist()
        {
            string sql = "select * from BooksSelect";
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
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
        public IEnumerable<BooksSelect> GetBooksSelects(string name)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where BOOKSNAME like '%{name}%'";
            using (IDbConnection conn = new OracleConnection(ConfigHelper.ConnString))
            {
                var bookslist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return bookslist;
            }
        }

        public IEnumerable<BooksSelect> GetBooksById(int id)
        {
            string sql = $"select * from BooksSelect b left join Picture p on b.id = p.booksselectid where b.id ='{id}'";
            using(IDbConnection conn=new OracleConnection(ConfigHelper.ConnString))
            {
                var bookslist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return bookslist;
            }
        }

               
    }
}
