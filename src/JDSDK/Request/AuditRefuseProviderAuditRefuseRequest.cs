using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AuditRefuseProviderAuditRefuseRequest : JdRequestBase<AuditRefuseProviderAuditRefuseResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  serviceId {get; set; }
                                                                                                                                                                                                public  		string
              approveNotes
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
                get{return "jingdong.AuditRefuseProvider.auditRefuse";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("serviceId", this.            serviceId
);
                                                                                                                                parameters.Add("approveNotes", this.            approveNotes
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





        
 

