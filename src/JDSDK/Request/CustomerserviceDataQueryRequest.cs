using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CustomerserviceDataQueryRequest : JdRequestBase<CustomerserviceDataQueryResponse>
    {
                                                                                  public  		string
              searchType
 {get; set;}
                                                          
                                                          public  		string
              startTime
 {get; set;}
                                                          
                                                          public  		string
              endTime
 {get; set;}
                                                          
                                                                                           public  		string
              groupId
 {get; set;}
                                                          
                                                          public  		string
              dimension
 {get; set;}
                                                          
                                                          public  		string
              queryType
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.customerservice.data.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("searchType", this.            searchType
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("dimension", this.            dimension
);
                                                                                                        parameters.Add("queryType", this.            queryType
);
                                                    }
    }
}





        
 

