using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderConfirmReject4JosRequest : JdRequestBase<MedicineDsOrderConfirmReject4JosResponse>
    {
                                                                                                                                              public  		string
              orderId
 {get; set;}
                                                          
                                                                                           public  		string
              operateMan
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              reqTimestamp
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.confirmReject4Jos";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                        parameters.Add("operateMan", this.            operateMan
);
                                                                                                        parameters.Add("reqTimestamp", this.            reqTimestamp
);
                                                                            }
    }
}





        
 

