using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryEntityStoreRequest : JdRequestBase<QueryEntityStoreResponse>
    {
                                                                                                                                              public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                                                           public  		string
              categoryName
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.queryEntityStore";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                                                        parameters.Add("categoryName", this.            categoryName
);
                                                                            }
    }
}





        
 

