using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderOrderStockOutRequest : JdRequestBase<MedicineDsOrderOrderStockOutResponse>
    {
                                                                                                                                              public  		string
              carrierName
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                                                           public  		string
              waybillCode
 {get; set;}
                                                          
                                                          public  		string
              operateMan
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              carrierId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.orderStockOut";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("carrierName", this.            carrierName
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                        parameters.Add("waybillCode", this.            waybillCode
);
                                                                                                        parameters.Add("operateMan", this.            operateMan
);
                                                                                                        parameters.Add("carrierId", this.            carrierId
);
                                                                            }
    }
}





        
 

