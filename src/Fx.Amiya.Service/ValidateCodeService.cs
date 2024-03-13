using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.ValidateCode;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class ValidateCodeService : IValidateCodeService
    {
        private IDalValidateCode dalValidateCode;
        public ValidateCodeService(IDalValidateCode dalValidateCode)
        {
            this.dalValidateCode = dalValidateCode;
        }

        public async Task<ValidateCodeDto> AddAsync(AddValidateCodeDto addDto)
        {
            try
            {
                ValidateCode validateCode = new ValidateCode();
                validateCode.Code = addDto.Code;
                validateCode.PhoneNumber = addDto.PhoneNumber;
                validateCode.ExpiredTime = DateTime.Now.AddSeconds(addDto.ExpireInSeconds);
                validateCode.CreateDate = DateTime.Now;
                validateCode.Valid = true;
                await dalValidateCode.AddAsync(validateCode, true);

                ValidateCodeDto validateCodeDto = new ValidateCodeDto();
                validateCodeDto.Id = validateCode.Id;
                validateCodeDto.Code = validateCode.Code;
                validateCodeDto.PhoneNumber = validateCode.PhoneNumber;
                validateCodeDto.ExpiredTime = validateCode.ExpiredTime;
                validateCodeDto.CreateDate = validateCode.CreateDate;
                validateCodeDto.Valid = validateCode.Valid;

                return validateCodeDto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<bool> ValidateAsync(string phone, string code)
        {
            try
            {
                var q = dalValidateCode.GetAll().Where(e => e.PhoneNumber == phone && e.Code == code && e.Valid && e.ExpiredTime > DateTime.Now);
                return await q.CountAsync() > 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
