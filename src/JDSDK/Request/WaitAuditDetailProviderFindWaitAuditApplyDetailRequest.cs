using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WaitAuditDetailProviderFindWaitAuditApplyDetailRequest : JdRequestBase<WaitAuditDetailProviderFindWaitAuditApplyDetailResponse>
    {
                                                                                                                                              public  		Nullable<int>
              afsApplyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              afsServiceStatus
 {get; set;}
                                                          
                                                          public  		string
              buId
 {get; set;}
                                                          
                                                                                                                      public  		string
              operatorPin
 {get; set;}
                                                          
                                                          public  		string
              operatorNick
 {get; set;}
                                                          
                                                          public  		string
              operatorRemark
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              operatorDate
 {get; set;}
                                                          
                                                          public  		string
              platformSrc
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.WaitAuditDetailProvider.findWaitAuditApplyDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("afsApplyId", this.            afsApplyId
);
                                                                                                        parameters.Add("afsServiceStatus", this.            afsServiceStatus
);
                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                                                                parameters.Add("operatorPin", this.            operatorPin
);
                                                                                                        parameters.Add("operatorNick", this.            operatorNick
);
                                                                                                        parameters.Add("operatorRemark", this.            operatorRemark
);
                                                                                                        parameters.Add("operatorDate", this.            operatorDate
);
                                                                                                        parameters.Add("platformSrc", this.            platformSrc
);
                                                                                                    }
    }
}





        
 

