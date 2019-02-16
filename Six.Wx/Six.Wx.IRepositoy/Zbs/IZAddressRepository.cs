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

        /// <summary>
        /// 添加一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        int AddAddresses(Address address);

        /// <summary>
        /// 修改一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        int UpdateAddresses(Address address);


        /// <summary>
        /// 删除一条收货地址
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        int DeleteAddresses(int id);
    }
}
