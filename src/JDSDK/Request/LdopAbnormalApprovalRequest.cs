using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAbnormalApprovalRequest : JdRequestBase<LdopAbnormalApprovalResponse>
    {
                                                                                                                                              public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              deliveryId
 {get; set;}
                                                          
                                                          public  		string
              responseComment
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.ldop.abnormal.approval";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                        parameters.Add("responseComment", this.            responseComment
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                                            }
    }
}





        
 

