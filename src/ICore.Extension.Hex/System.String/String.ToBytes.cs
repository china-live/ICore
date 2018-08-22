using System;

namespace ICore.Extension.Hex
{
    public static partial class Extensions
    {
        /// <summary>
        /// 将16进制字符串转换为字节数组
        /// </summary>
        /// <param name="this">有效的16进制字符串（2个字符为一个字节，只能包含[0-9][A-F]，不区别大小写）</param>
        public static byte[] HexToBytes(this string @this)
        {
            if (string.IsNullOrWhiteSpace(@this))
                throw new ArgumentNullException($"{nameof(@this)}");
            if ((@this.Length % 2) != 0)
                throw new ArgumentException($"{nameof(@this)} 不是有效的16进制字符串");

            var len = @this.Length / 2;
            byte[] result = new byte[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = Convert.ToByte(@this.Substring(i * 2, 2), 16);
            }
            return result;
        }
    }
}


