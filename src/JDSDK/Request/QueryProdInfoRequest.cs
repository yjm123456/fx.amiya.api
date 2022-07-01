using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryProdInfoRequest : JdRequestBase<QueryProdInfoResponse>
    {
                                                                                                                                              public  		Nullable<long>
              shopId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              projectId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  skuList {get; set; }
                                                                                                                                                                                                public  		string
              isProduct
 {get; set;}
                                                          
                                                                                           public  		string
              bizToken
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.queryProdInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("shopId", this.            shopId
);
                                                                                                        parameters.Add("projectId", this.            projectId
);
                                                                                                                                                parameters.Add("skuList", this.            skuList
);
                                                                                                                                parameters.Add("isProduct", this.            isProduct
);
                                                                                                                                                        parameters.Add("bizToken", this.            bizToken
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                            }
    }
}





        
 

