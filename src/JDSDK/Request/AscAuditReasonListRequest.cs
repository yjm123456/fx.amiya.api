using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscAuditReasonListRequest : JdRequestBase<AscAuditReasonListResponse>
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
                                                          
                                                          public  		string
              parentCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              bizType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.audit.reason.list";}
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
                                                                                                        parameters.Add("parentCode", this.            parentCode
);
                                                                                                        parameters.Add("bizType", this.            bizType
);
                                                                            }
    }
}





        
 

