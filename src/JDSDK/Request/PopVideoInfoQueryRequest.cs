using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopVideoInfoQueryRequest : JdRequestBase<PopVideoInfoQueryResponse>
    {
                                                                                                                                                                               public  		string
                                                                                      videoName
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                      public  		string
              statuses
 {get; set;}
                                                          
                                                          public  		Nullable<long>
                                                                                                                      agentVideoId
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                      videoType
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                                                      createdDateStart
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                      createdDateEnd
 {get; set;}
                                                                                                                                                          
                                                          public  		string
              order
 {get; set;}
                                                          
                                                          public  		string
                                                                                      orderBy
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageIndex
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.pop.video.info.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("video_name", this.                                                                                    videoName
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                        parameters.Add("statuses", this.            statuses
);
                                                                                                        parameters.Add("agent_video_id", this.                                                                                                                    agentVideoId
);
                                                                                                        parameters.Add("video_type", this.                                                                                    videoType
);
                                                                                                        parameters.Add("created_date_start", this.                                                                                                                    createdDateStart
);
                                                                                                        parameters.Add("created_date_end", this.                                                                                                                    createdDateEnd
);
                                                                                                        parameters.Add("order", this.            order
);
                                                                                                        parameters.Add("order_by", this.                                                                                    orderBy
);
                                                                                                        parameters.Add("page_index", this.                                                                                    pageIndex
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

