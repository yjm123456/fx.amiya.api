using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopVideoSkuRelativeQueryRequest : JdRequestBase<PopVideoSkuRelativeQueryResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      videoId
 {get; set;}
                                                                                                                                  
                                                                                           public  		Nullable<long>
                                                                                      productId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                      public  		string
              statuses
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              videoType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.pop.video.sku.relative.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("video_id", this.                                                                                    videoId
);
                                                                                                                                                        parameters.Add("product_id", this.                                                                                    productId
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("statuses", this.            statuses
);
                                                                                                        parameters.Add("videoType", this.            videoType
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

