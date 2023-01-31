using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.Dto.GoodsConsumptionVoucher;
using Fx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ICustomerConsumptionVoucherService
    {
        /// <summary>
        /// 给用户添加新的抵用券
        /// </summary>
        /// <param name="addCustomerConsumption"></param>
        /// <returns></returns>
        Task AddAsyn(AddCustomerConsumptionVoucherDto addCustomerConsumption);
        /// <summary>
        /// 分页获取用户抵用券列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="customerId"></param>
        /// <param name="type">0未使用,1已使用,2已过期</param>
        /// <returns></returns>
        Task<FxPageInfo<CustomerConsumptioVoucherInfoDto>> GetCustomerConsumptionVoucherListAsync(int pageNum,int pageSize,string customerId, int? type);
        /// <summary>
        /// 获取当前商品可用的抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="isUsed">是否使用</param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        Task<List<CustomerConsumptioVoucherInfoDto>> GetAllCustomerConsumptionVoucherListAsync(string customerId, bool? isUsed,string goodsId);
        /// <summary>
        /// 获取当前可用的预约叫车抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="isUsed">是否使用</param>
        /// <param name="goodsId">商品id</param>
        /// <returns></returns>
        Task<List<CustomerConsumptioVoucherInfoDto>> GetAllCustomerConsumptionCarVoucherListAsync(string customerId);
        /// <summary>
        /// 普通会员发放抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="source">抵用券来源 0,会员赠送,1分享,2每月领取</param>
        Task OrdinaryMemberSendVoucherAsync(string customerId,int source);
        /// <summary>
        /// 白金卡会员发放抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="source">抵用券来源 0,会员赠送,1分享,2每月领取</param>
        /// <returns></returns>
        Task MEIYAWhiteCardMemberSendVoucherAsync(string customerId, int source);
        /// <summary>
        /// 黑金会员发放抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="source">抵用券来源 0,会员赠送,1分享,2每月领取</param>
        Task BlackCardMemberSendVoucherAsync(string customerId, int source);
        /// <summary>
        /// 分享抵用券
        /// </summary>
        /// <returns></returns>
        Task ShareCustomerConsumptionVoucherAsync(ShareCustomerConsumptionVoucherDto shareCustomerConsumption);
        /// <summary>
        /// 修改用户抵用券使用状态
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task UpdateCustomerConsumptionVoucherUseStatusAsync(UpdateCustomerConsumptionVoucherDto updateUseStateDto);
        /// <summary>
        /// 用户领取分享的抵用券
        /// </summary>
        /// <param name="customerId">领取人id</param>
        /// <param name="voucherCode">抵用券编码</param>
        /// <param name="shareBy">分享人</param>
        /// <returns></returns>
        Task ReceiveShareConsumptionVoucherAsync(AddCustomerConsumptionVoucherDto addCustomerConsumptionVoucher);
        /// <summary>
        /// 根据用户id和抵用券id获取指定的抵用券信息
        /// </summary>
        /// <param name="customrtid"></param>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        Task<CustomerConsumptioVoucherInfoDto> GetVoucherByCustomerIdAndVoucherIdAsync(string customrtid,string voucherid);
        /// <summary>
        /// 用户每月领取会员卡
        /// </summary>
        /// <returns></returns>
        Task MemberRecieveCardAsync(string customerId);
        /// <summary>
        /// 当前月是否已领取过抵用券
        /// </summary>
        /// <param name="customerId">用户id</param>
        /// <returns></returns>
        Task<bool> IsReciveVoucherThisMonthAsync(string customerId);
        /// <summary>
        /// 新用户绑定赠送抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task NewCustomerSendVoucherAsync(string customerId);
        /// <summary>
        /// 判断最近30天有没有领取过会员赠送券,没有则发放,有则不发放
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<List<MemberRecieveConsumptionVoucherDto>> IsReciveVoucherThisMonthThisWeekAsync(string customerId);
        /// <summary>
        /// 获取有效的叫车抵用券
        /// </summary>
        /// <param name="customerid"></param>
        /// <param name="voucherid"></param>
        /// <returns></returns>
        Task<CustomerConsumptioVoucherInfoDto> GetCarVoucherByCustomerIdAndVoucherIdAsync(string customerid, string voucherid);
        Task<CustomerConsumptioVoucherInfoDto> GetCarTypeVoucherByCustomerIdAndVoucherIdAsync(string customerid, string carType);
        /// <summary>
        /// 用户每周领取抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="voucherCode">抵用券编码</param>
        /// <returns></returns>
        Task MemberRecieveCardWeekAsync(string customerId,string voucherCode);
        /// <summary>
        /// 获取用户可用于全局商品的抵用券
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="isUsed"></param>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        Task<List<CustomerConsumptioVoucherInfoDto>> GetOverAllCustomerConsumptionVoucherListAsync(string customerId, bool? isUsed, string goodsId);
        /// <summary>
        /// 获取可用的商品抵用券(不包含叫车抵用券)
        /// </summary>
        /// <returns></returns>
        Task<List<SimpleVoucherInfoDto>> GetCustomerAllVoucher(string customerId); 
    }
}
