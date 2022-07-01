using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscProcessJdInterveneRequest : JdRequestBase<AscProcessJdInterveneResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sysVersion
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              interveneReasonCid1
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              interveneReasonCid2
 {get; set;}
                                                          
                                                          public  		string
              contactTel
 {get; set;}
                                                          
                                                          public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.process.JdIntervene";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("sysVersion", this.            sysVersion
);
                                                                                                        parameters.Add("interveneReasonCid1", this.            interveneReasonCid1
);
                                                                                                        parameters.Add("interveneReasonCid2", this.            interveneReasonCid2
);
                                                                                                        parameters.Add("contactTel", this.            contactTel
);
                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

