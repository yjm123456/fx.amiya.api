using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopAlphaProviderAutoRecycleDetailRequest : JdRequestBase<LdopAlphaProviderAutoRecycleDetailResponse>
    {
                                                                                                                                              public  		string
              providerCode
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                                                                                            public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ldop.alpha.provider.autoRecycleDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("providerCode", this.            providerCode
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                    }
    }
}





        
 

