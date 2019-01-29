using System;
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
    public interface IZappointment
    {
        /// <summary>
        /// 查询所有的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Classification> GetClassifications();

        /// <summary>
        /// 查询部分的图书信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Classification> GetClassifications(string name);
    }
}
