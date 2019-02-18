using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Six.Wx.Model;

namespace Six.Wx.IRepositoy.Fdy
{
    public interface ISearchRepository
    {
        /// <summary>
        /// 获取所有的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetAllBooks(); 

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBookByName(string name, int typeid); 

        /// <summary>
        /// 查询一条的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBookByID(int id);
    }
}
