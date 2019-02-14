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
        /// 返回所有图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksSelects();
        //List<BooksSelect> GetBooksSelects();

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetSumBooksSelects(string name);

        /// <summary>
        /// 查询一条的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetOneBooksSelects(int id);
    }
}
