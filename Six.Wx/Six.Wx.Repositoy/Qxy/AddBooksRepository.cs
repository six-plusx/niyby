using Six.Wx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using Dapper;
using Six.Wx.IRepositoy.Qxy;

namespace Six.Wx.Repositoy.Qxy
{
    /// <summary>
    /// 录入图书的实现类
    /// </summary>
    public class AddBooksRepository: IAddBooksRepository
    {
        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        public static string strConn = ConfigHelper.ConnString;

        /// <summary>
        /// 显示图书信息列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BooksSelect> GetBooksSelects()
        {
            string sql = "select * from BooksSelect";
            using(IDbConnection conn=new OracleConnection(strConn))
            {
                var bookslist = conn.Query<BooksSelect>(sql);
                conn.Close();
                return bookslist;
            }
        }

        /// <summary>
        /// 添加图书
        /// </summary>
        /// <returns></returns>
        public int AddBooks(BooksSelect booksSelect)
        {
            string sql = string.Format("insert into BooksSelect(BooksName,Author,Price,Message,EnterNum,Catalogue，State)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",booksSelect.BooksName,booksSelect.Author,booksSelect.Price,booksSelect.Message,booksSelect.EnterNum,booksSelect.Catalogue,booksSelect.State);
            using(IDbConnection conn=new OracleConnection(strConn))
            {
                var i = conn.Execute(sql);
                conn.Close();
                return i;
            }
        }
    }
}
