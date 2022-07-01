using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopOrderEnSearchRequest : JdRequestBase<PopOrderEnSearchResponse>
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
                                                                                      optionalFields
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                          public  		string
              sortType
 {get; set;}
                                                          
                                                          public  		string
              dateType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.order.enSearch";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("start_date", this.                                                                                    startDate
);
                                                                                                        parameters.Add("end_date", this.                                                                                    endDate
);
                                                                                                        parameters.Add("order_state", this.                                                                                    orderState
);
                                                                                                        parameters.Add("optional_fields", this.                                                                                    optionalFields
);
                                                                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                        parameters.Add("sortType", this.            sortType
);
                                                                                                        parameters.Add("dateType", this.            dateType
);
                                                                            }
    }
}





        
 

