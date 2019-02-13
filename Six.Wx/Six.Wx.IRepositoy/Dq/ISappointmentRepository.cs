using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Six.Wx.Model;

namespace Six.Wx.IRepositoy.Dq
{
    /// <summary>
    /// 图书查询---已购的图书
    /// </summary>
    public interface ISappointmentRepository
    {
        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksSelects();

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
