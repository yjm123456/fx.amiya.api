using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Integration
{
    public class IntegrationgenerationRecordDto
    {
        public long Id { get; set; }
        //客户id
        public string CustomerId { get; set; }
        //手机号
        public string Phone { get; set; }
        //发放时间
        public DateTime CreateDate { get; set; }
        //积分类型
        public string TypeText { get; set; }
        //发放数量
        public decimal Quantity { get; set; }
        //订单id
        public string OrderId { get; set; }
        //消费金额
        public decimal ConsumptionAmount { get; set; }
        //生成比例
        public decimal Percent { get; set; }
        //该记录剩余的积分
        public decimal StockQuantity { get; set; }
        //用户积分余额
        public decimal AccountBalance { get; set; }
        //发放人
        public string HandleBy { get; set; }
    }
}
