using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Six.Wx.Model;
using Six.Wx.IRepositoy;
using System.Configuration; //链接字符串所用的命名空间

namespace Six.Wx.Repositoy
{
    /// <summary>
    /// 实现层-----图书
    /// </summary>
    public class BookRepositoy
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
    }
}
