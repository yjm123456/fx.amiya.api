using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiReturnorderAuditRequest : JdRequestBase<YunpeiReturnorderAuditResponse>
    {
                                                                                                                   public  		string
                                                                                                                      returnBillSn
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                      isAgree
 {get; set;}
                                                                                                                                  
                                                          public  		string
              opinion
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.yunpei.returnorder.audit";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("return_bill_sn", this.                                                                                                                    returnBillSn
);
                                                                                                        parameters.Add("is_agree", this.                                                                                    isAgree
);
                                                                                                        parameters.Add("opinion", this.            opinion
);
                                                    }
    }
}





        
 

