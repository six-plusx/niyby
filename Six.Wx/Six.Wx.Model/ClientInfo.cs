using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx
{
    public class ClientInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// OpendId
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 用户令牌
        /// </summary>
        public string session_key { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get; set; }
    }
}
