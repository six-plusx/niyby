using Six.Wx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.IRepositoy.Qxy
{
    /// <summary>
    /// 已录入图书接口
    /// </summary>
    public interface IAleadyBooksRepository
    {
        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="booksSelect"></param>
        /// <returns></returns>
        int AddBooks(BooksSelect booksSelect);

        /// <summary>
        /// 返回所有图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksSelectlist();
        //List<BooksSelect> GetBooksSelects();

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksSelects(string name);

        /// <summary>
        /// 查询一条的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksById(int id);
    }
}
