using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderFbpSearchRequest : JdRequestBase<PopOrderFbpSearchResponse>
    {
                                                                                                                                                                               public  		string
              startDate
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              orderState
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              colType
 {get; set;}
                                                          
                                                          public  		string
              optionalFields
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              sortType
 {get; set;}
                                                          
                                                          public  		string
              dateType
 {get; set;}
                                                          
                                                          public  		string
              storeId
 {get; set;}
                                                          
                                                          public  		string
              cky2
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.fbp.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("orderState", this.            orderState
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("colType", this.            colType
);
                                                                                                        parameters.Add("optionalFields", this.            optionalFields
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                                                                        parameters.Add("dateType", this.            dateType
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("cky2", this.            cky2
);
                                                                            }
    }
}





        
 

