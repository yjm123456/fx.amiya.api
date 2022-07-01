using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ApiSmsModelConfigWriteServiceSendSmsRequest : JdRequestBase<ApiSmsModelConfigWriteServiceSendSmsResponse>
    {
                                                                                                                                                                                                                public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                                                                                                                                                        public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              pin
 {get; set;}
                                                          
                                                          public  		string
              batchNo
 {get; set;}
                                                          
                                                          public  		string
              phoneNo
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.api.SmsModelConfigWriteService.sendSms";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                parameters.Add("id", this.            id
);
                                                                                                                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("pin", this.            pin
);
                                                                                                        parameters.Add("batchNo", this.            batchNo
);
                                                                                                        parameters.Add("phoneNo", this.            phoneNo
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                                            }
    }
}





        
 

