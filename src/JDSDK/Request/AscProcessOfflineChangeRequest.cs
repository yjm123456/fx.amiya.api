using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscProcessOfflineChangeRequest : JdRequestBase<AscProcessOfflineChangeResponse>
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
                                                          
                                                          public  		string
              operateRemark
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
              opFlag
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              partExpressId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              shipWayId
 {get; set;}
                                                          
                                                          public  		string
              shipWayName
 {get; set;}
                                                          
                                                          public  		string
              expressCode
 {get; set;}
                                                          
                                                          public  		string
              relationBillId
 {get; set;}
                                                          
                                                          public  		string
              wareType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              partSrc
 {get; set;}
                                                          
                                                          public  		string
              extJsonStr
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              wareNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.process.offline.change";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("operateRemark", this.            operateRemark
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("sysVersion", this.            sysVersion
);
                                                                                                        parameters.Add("opFlag", this.            opFlag
);
                                                                                                        parameters.Add("partExpressId", this.            partExpressId
);
                                                                                                        parameters.Add("shipWayId", this.            shipWayId
);
                                                                                                        parameters.Add("shipWayName", this.            shipWayName
);
                                                                                                        parameters.Add("expressCode", this.            expressCode
);
                                                                                                        parameters.Add("relationBillId", this.            relationBillId
);
                                                                                                        parameters.Add("wareType", this.            wareType
);
                                                                                                        parameters.Add("partSrc", this.            partSrc
);
                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                                                        parameters.Add("wareNum", this.            wareNum
);
                                                                            }
    }
}





        
 

