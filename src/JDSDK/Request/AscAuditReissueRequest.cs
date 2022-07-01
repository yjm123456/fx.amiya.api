using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscAuditReissueRequest : JdRequestBase<AscAuditReissueResponse>
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
                                                          
                                                          public  		string
              approveNotes
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sysVersion
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              approveReasonCid1
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              approveReasonCid2
 {get; set;}
                                                          
                                                          public  		string
              expressCode
 {get; set;}
                                                          
                                                          public  		string
              shipWayId
 {get; set;}
                                                          
                                                          public  		string
              shipWayName
 {get; set;}
                                                          
                                                          public  		string
              operateRemark
 {get; set;}
                                                          
                                                          public  		string
              extJsonStr
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              wareNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.audit.reissue";}
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
                                                                                                        parameters.Add("approveNotes", this.            approveNotes
);
                                                                                                        parameters.Add("sysVersion", this.            sysVersion
);
                                                                                                        parameters.Add("approveReasonCid1", this.            approveReasonCid1
);
                                                                                                        parameters.Add("approveReasonCid2", this.            approveReasonCid2
);
                                                                                                        parameters.Add("expressCode", this.            expressCode
);
                                                                                                        parameters.Add("shipWayId", this.            shipWayId
);
                                                                                                        parameters.Add("shipWayName", this.            shipWayName
);
                                                                                                        parameters.Add("operateRemark", this.            operateRemark
);
                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                                                        parameters.Add("wareNum", this.            wareNum
);
                                                                            }
    }
}





        
 

