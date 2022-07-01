using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class GxptDirectPayQueryRequest : JdRequestBase<GxptDirectPayQueryResponse>
    {
                                                                                                                                              public  		string
              startCreated
 {get; set;}
                                                          
                                                          public  		string
              endCreated
 {get; set;}
                                                          
                                                          public  		string
              startModified
 {get; set;}
                                                          
                                                          public  		string
              endModified
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              payType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              payState
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.gxpt.directPay.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("startCreated", this.            startCreated
);
                                                                                                        parameters.Add("endCreated", this.            endCreated
);
                                                                                                        parameters.Add("startModified", this.            startModified
);
                                                                                                        parameters.Add("endModified", this.            endModified
);
                                                                                                        parameters.Add("payType", this.            payType
);
                                                                                                        parameters.Add("payState", this.            payState
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                                            }
    }
}





        
 

