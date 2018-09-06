using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class UserModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public SexEnum Sex { get; set; }
    }

    public enum SexEnum
    {
        /// <summary>
        /// 男性
        /// </summary>
        Man=1,
        /// <summary>
        /// 女性
        /// </summary>
        Woman=2
    }
}