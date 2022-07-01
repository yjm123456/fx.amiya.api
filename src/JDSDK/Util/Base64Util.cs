using System.Linq;
using System.Web;

namespace jos_sdk_net.Util
{
   public class Base64Util
    {
        private static char[] base64CodeArray = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4',  '5', '6', '7', '8', '9', '+', '/', '='
        };

        /// <summary>
        /// 是否base64字符串，如果字符串是url编码的请先进行url解码，否则会判定为非base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsBase64(string base64Str)
        {
            if (string.IsNullOrEmpty(base64Str))
                return false;
            else
            {
                if (base64Str.Length % 4 != 0)
                    return false;
                
                if (base64Str.Any(c => !base64CodeArray.Contains(c)))
                    return false;
            }
            return true;
        }
    }
}
