using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Six.Wx.Model;

namespace Six.Wx.IRepositoy.Zbs
{
    /// <summary>
    /// 收货地址接口
    /// </summary>
    public interface IZAddressRepository
    {
        /// <summary>
        /// 返回所有的收货地址
        /// </summary>
        /// <returns></returns>
        IEnumerable<Address> GetAllAddresses();


        /// <summary>
        /// 返回一条的收货地址
        /// </summary>
        /// <returns></returns>
        IEnumerable<Address> GetOneAddresses(int id);
    }
}
