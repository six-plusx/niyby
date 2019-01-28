using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six.Wx.Model
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 主键 角色id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string RpName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int RoleState { get; set; }

        /// <summary>
        /// 关联表的权限id
        /// </summary>
        public string Rpid { get; set; }

    }
}
