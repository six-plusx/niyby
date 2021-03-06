﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Six.Wx.Model;

namespace Six.Wx.IRepositoy.Zbs
{
    /// <summary>
    /// 图书查询----预约的图书
    /// </summary>
    public interface IZappointmentRepository
    {
        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetAllBooks();

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksByName(string name, int typeid);

        /// <summary>
        /// 查询一条的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<BooksSelect> GetBooksById(int id);
    }
}
