using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class QueryJDPriceRequest : JdRequestBase<QueryJDPriceResponse>
    {
                                                                                                                   public  		string
              bizToken
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              shopId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              projectId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  skuidList {get; set; }
                                                                                                                                                                                                public  		string
              source
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.queryJDPrice";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("bizToken", this.            bizToken
);
                                                                                                        parameters.Add("shopId", this.            shopId
);
                                                                                                        parameters.Add("projectId", this.            projectId
);
                                                                                                                                                parameters.Add("skuidList", this.            skuidList
);
                                                                                                                                parameters.Add("source", this.            source
);
                                                    }
    }
}





        
 

