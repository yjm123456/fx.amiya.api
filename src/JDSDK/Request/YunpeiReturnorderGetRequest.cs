using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiReturnorderGetRequest : JdRequestBase<YunpeiReturnorderGetResponse>
    {
                                                                                                                   public  		string
                                                                                                                      returnBillSn
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.yunpei.returnorder.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("return_bill_sn", this.                                                                                                                    returnBillSn
);
                                                    }
    }
}





        
 

