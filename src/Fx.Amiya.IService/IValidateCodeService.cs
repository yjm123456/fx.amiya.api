using Fx.Amiya.Dto.ValidateCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IValidateCodeService
    {
        /// <summary>
        /// 添加验证码
        /// </summary>
        /// <param name="addDto"></param>
        /// <returns></returns>
        Task<ValidateCodeDto> AddAsync(AddValidateCodeDto addDto);


        /// <summary>
        /// 验证验证码是否有效
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<bool> ValidateAsync(string phone, string code);
    }
}
