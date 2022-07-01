using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class InnovationProductReadGetSkuListRequest : JdRequestBase<InnovationProductReadGetSkuListResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  spuId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  skuId {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              categoryId
 {get; set;}
                                                          
                                                                                           public  		string
              title
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.innovation.product.read.getSkuList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("spuId", this.            spuId
);
                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                                                parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                                                                        parameters.Add("title", this.            title
);
                                                                            }
    }
}





        
 

