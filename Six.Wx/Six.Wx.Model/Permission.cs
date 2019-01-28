using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightGroups.Erp.Model
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// 角色权限id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public string PermissionPer { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        public string PermissionUrl { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public int PermissionFatherId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int PermissionStart { get; set; }
    }
}
