using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderUserPickUpGoodsRequest : JdRequestBase<MedicineDsOrderUserPickUpGoodsResponse>
    {
                                                                                                                                              public  		string
              pickUpCode
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                                                           public  		string
              operateMan
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.userPickUpGoods";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("pickUpCode", this.            pickUpCode
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                        parameters.Add("operateMan", this.            operateMan
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                            }
    }
}





        
 

