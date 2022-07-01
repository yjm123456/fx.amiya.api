using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiOrderShippingRequest : JdRequestBase<YunpeiOrderShippingResponse>
    {
                                                                                  public  		string
                                                                                      orderSn
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      companyName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      deliveryBillId
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      gtmDelivery
 {get; set;}
                                                                                                                                  
                                                          public  		string
              remark
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.yunpei.order.shipping";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("order_sn", this.                                                                                    orderSn
);
                                                                                                        parameters.Add("company_name", this.                                                                                    companyName
);
                                                                                                        parameters.Add("delivery_bill_id", this.                                                                                                                    deliveryBillId
);
                                                                                                        parameters.Add("gtm_delivery", this.                                                                                    gtmDelivery
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                    }
    }
}





        
 

