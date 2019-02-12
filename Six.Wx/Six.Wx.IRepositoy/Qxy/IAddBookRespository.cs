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
    public interface IAddBookRespository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="booksSelect"></param>
        /// <returns></returns>
        int AddBoook(BooksSelect booksSelect);

        /// <summary>
        /// 显示图书列表
        /// </summary>
        /// <returns></returns>
        List<BooksSelect> GetBooksSelects();



    }
}
