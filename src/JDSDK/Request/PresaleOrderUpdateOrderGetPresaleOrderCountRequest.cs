using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PresaleOrderUpdateOrderGetPresaleOrderCountRequest : JdRequestBase<PresaleOrderUpdateOrderGetPresaleOrderCountResponse>
    {
                                                                                                                                              public  		string
              userPin
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  orderStatusItem {get; set; }
                                                                                                                                                                                                public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                                                           public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              skuID
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.presale.order.updateOrder.getPresaleOrderCount";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("userPin", this.            userPin
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                parameters.Add("orderStatusItem", this.            orderStatusItem
);
                                                                                                                                parameters.Add("startTime", this.            startTime
);
                                                                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("skuID", this.            skuID
);
                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                                            }
    }
}





        
 

