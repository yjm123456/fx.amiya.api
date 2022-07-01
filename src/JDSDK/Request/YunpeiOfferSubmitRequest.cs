using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiOfferSubmitRequest : JdRequestBase<YunpeiOfferSubmitResponse>
    {
                                                                                                                   public  		string
                                                                                      demandSn
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      shippingType
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      shippingPayWay
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      otherFee
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      offerDetailParams
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      operateName
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.yunpei.offer.submit";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("demand_sn", this.                                                                                    demandSn
);
                                                                                                        parameters.Add("shipping_type", this.                                                                                    shippingType
);
                                                                                                        parameters.Add("shipping_pay_way", this.                                                                                                                    shippingPayWay
);
                                                                                                        parameters.Add("other_fee", this.                                                                                    otherFee
);
                                                                                                        parameters.Add("offer_detail_params", this.                                                                                                                    offerDetailParams
);
                                                                                                        parameters.Add("operate_name", this.                                                                                    operateName
);
                                                    }
    }
}





        
 

