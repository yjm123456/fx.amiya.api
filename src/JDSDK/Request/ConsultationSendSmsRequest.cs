using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ConsultationSendSmsRequest : JdRequestBase<ConsultationSendSmsResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.consultation.sendSms";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                                            }
    }
}





        
 

