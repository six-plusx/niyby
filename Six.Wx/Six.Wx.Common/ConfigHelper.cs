using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Six.Wx.Common
{
    public static class ConfigHelper
    {
        #region 获取自定义返回值信息
        /// <summary>
        /// 自定义获取配置文件中的值
        /// </summary>
        /// <param name="strConfigKey">节点名称</param>
        /// <returns></returns>
        public static string GetConfigValue(string strConfigKey)
        {
            return ConfigurationManager.AppSettings[strConfigKey];
        }
        #endregion

        #region 连接数据库字符串
        private static string _conStr = string.Empty;

        public static string ConnString
        {
            get
            {
                _conStr = GetConfigValue("conStr");
                //_conStr = ConfigurationManager.AppSettings["conStr"];
                return _conStr;
            }
        }
        #endregion

        #region  /// Redis服务器地址及端口号

        private static string _redisServiceUrl = string.Empty;

        /// <summary>
        /// Redis服务器地址 
        /// </summary>
        public static string RedisServiceUrl
        {
            get
            {
                _redisServiceUrl = GetConfigValue("RedisServiceUrl");
                // _redisServiceUrl = ConfigurationManager.AppSettings["RedisServiceUrl"];
                return _redisServiceUrl;
            }
        }

        private static int _redisServicePortNum = 0;

        /// <summary>
        /// Redis服务器端口号
        /// </summary>
        public static int RedisServicePortNum
        {
            get
            {
                _redisServicePortNum = int.Parse(GetConfigValue("RedisServicePortNum"));
                return _redisServicePortNum;
            }
        }

        #endregion
    }
}
