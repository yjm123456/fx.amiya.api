using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiDeliverorderGetRequest : JdRequestBase<YunpeiDeliverorderGetResponse>
    {
                                                                                                                   public  		string
                                                                                                                      wayBillNo
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.yunpei.deliverorder.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("way_bill_no", this.                                                                                                                    wayBillNo
);
                                                    }
    }
}





        
 

