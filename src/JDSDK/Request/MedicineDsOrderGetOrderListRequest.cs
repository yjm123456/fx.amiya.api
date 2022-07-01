using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class MedicineDsOrderGetOrderListRequest : JdRequestBase<MedicineDsOrderGetOrderListResponse>
    {
                                                                                                                                              public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              clientIp
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              startDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              agingType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.medicine.ds.order.getOrderList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("clientIp", this.            clientIp
);
                                                                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("orderStatus", this.            orderStatus
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("agingType", this.            agingType
);
                                                                            }
    }
}





        
 

