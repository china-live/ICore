using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ICore.Extension.Hex
{
    public static partial class Extensions
    {
        /// <summary>
        /// 转换为16进制字符串
        /// </summary>
        /// <param name="this">待转换的、有效的16进制字节数组</param>
        /// <param name="format">"X2"、"x2" 分别输入大写、小写格式</param>
        public static string ToHex(this byte[] @this, string format = "X2")
        {
            if (@this == null)
                return default(string);
 
            return string.Concat(@this.Select(c => c.ToString(format)));
        }


        /// <summary>
        /// 转换为16进制字符串
        /// </summary>
        /// <param name="this">待转换的、有效的16进制字节集合</param>
        /// <param name="format">"X2"、"x2" 分别输入大写、小写格式</param>
        /// <returns></returns>
        public static string ToHex(this IEnumerable<byte> @this, string format = "X2")
        {
            if (@this == null)
                return default(string);

            return string.Concat(@this.Select(c => c.ToString(format)));
        }

        /// <summary>
        /// 转换为16进制字符串
        /// </summary>
        /// <param name="this">一个有效的16进制字节</param>
        /// <param name="format">"X2"、"x2" 分别输入大写、小写格式</param>
        /// <returns></returns>
        public static string ToHex(this byte @this, string format = "X2")
        {
            return @this.ToString(format);
        }
    }
}

