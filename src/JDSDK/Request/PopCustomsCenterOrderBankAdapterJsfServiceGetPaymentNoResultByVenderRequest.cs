using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopCustomsCenterOrderBankAdapterJsfServiceGetPaymentNoResultByVenderRequest : JdRequestBase<PopCustomsCenterOrderBankAdapterJsfServiceGetPaymentNoResultByVenderResponse>
    {
                                                                                  public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.customs.center.OrderBankAdapterJsfService.getPaymentNoResultByVender";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                    }
    }
}





        
 

