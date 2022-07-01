using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiReturnOrderConfirmRequest : JdRequestBase<YunpeiReturnOrderConfirmResponse>
    {
                                                                                  public  		string
              appKey
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      returnBillSn
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.yunpei.returnOrder.confirm";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("appKey", this.            appKey
);
                                                                                                        parameters.Add("return_bill_sn", this.                                                                                                                    returnBillSn
);
                                                    }
    }
}





        
 

