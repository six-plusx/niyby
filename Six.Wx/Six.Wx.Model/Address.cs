using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 地址表
    /// </summary>
    public class Address
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>
        /// 锁在地区
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Loction { get; set; }
    }
}
