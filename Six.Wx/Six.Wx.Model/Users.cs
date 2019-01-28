using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string UsersUser { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string UsersPwd { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string UsersRePeople { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UsersDataTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int UsersState { get; set; }

        /// <summary>
        /// 关联表的角色id
        /// </summary>
        public string Urid { get; set; }
    }
}
