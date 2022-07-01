using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FactoryProductQueryProductByPageRequest : JdRequestBase<FactoryProductQueryProductByPageResponse>
    {
                                                                                                                                              public  		string
              personalKey
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              ptId
 {get; set;}
                                                          
                                                                                                                                                                                                                         public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              materialType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              subType
 {get; set;}
                                                          
                                                                                      public  		string
              skuList
 {get; set;}
                                                          
                                                                                           public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.factory.product.queryProductByPage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("personalKey", this.            personalKey
);
                                                                                                        parameters.Add("ptId", this.            ptId
);
                                                                                                                                                                                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("materialType", this.            materialType
);
                                                                                                        parameters.Add("subType", this.            subType
);
                                                                                                        parameters.Add("skuList", this.            skuList
);
                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                    }
    }
}





        
 

