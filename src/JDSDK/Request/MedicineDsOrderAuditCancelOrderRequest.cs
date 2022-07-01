using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderAuditCancelOrderRequest : JdRequestBase<MedicineDsOrderAuditCancelOrderResponse>
    {
                                                                                                                                              public  		string
              rejectReason
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              cancelOrderId
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              outOfDeptActual
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              rejectType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              auditType
 {get; set;}
                                                          
                                                          public  		string
              operateMan
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              reqTimestamp
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.auditCancelOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("rejectReason", this.            rejectReason
);
                                                                                                        parameters.Add("cancelOrderId", this.            cancelOrderId
);
                                                                                                        parameters.Add("outOfDeptActual", this.            outOfDeptActual
);
                                                                                                                                                        parameters.Add("rejectType", this.            rejectType
);
                                                                                                        parameters.Add("auditType", this.            auditType
);
                                                                                                        parameters.Add("operateMan", this.            operateMan
);
                                                                                                        parameters.Add("reqTimestamp", this.            reqTimestamp
);
                                                                            }
    }
}





        
 

