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
