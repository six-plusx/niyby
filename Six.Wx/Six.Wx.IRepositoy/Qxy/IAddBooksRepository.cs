using Six.Wx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.IRepositoy.Qxy
{
    /// <summary>
    /// 录入图书的接口
    /// </summary>
    public interface IAddBooksRepository
    {
        /// <summary>
        /// 返回所有图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksSelects();
        //List<BooksSelect> GetBooksSelects();

        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="booksSelect"></param>
        /// <returns></returns>
        int AddBooks(BooksSelect booksSelect);
    }
}
