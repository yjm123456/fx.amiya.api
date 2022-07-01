using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopPopCommentJsfServiceGetVenderCommentsForJosRequest : JdRequestBase<PopPopCommentJsfServiceGetVenderCommentsForJosResponse>
    {
                                                                                                                                              public  		string
              skuids
 {get; set;}
                                                          
                                                                                           public  		string
              wareName
 {get; set;}
                                                          
                                                          public  		string
              beginTime
 {get; set;}
                                                          
                                                          public  		string
              endTime
 {get; set;}
                                                          
                                                          public  		string
              score
 {get; set;}
                                                          
                                                          public  		string
              content
 {get; set;}
                                                          
                                                          public  		string
              pin
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              isVenderReply
 {get; set;}
                                                          
                                                          public  		string
              cid
 {get; set;}
                                                          
                                                          public  		string
              orderIds
 {get; set;}
                                                          
                                                          public  		string
              page
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                                                           public  		string
                                                                                                                      openIdBuyer
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.PopCommentJsfService.getVenderCommentsForJos";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("skuids", this.            skuids
);
                                                                                                                                                        parameters.Add("wareName", this.            wareName
);
                                                                                                        parameters.Add("beginTime", this.            beginTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("score", this.            score
);
                                                                                                        parameters.Add("content", this.            content
);
                                                                                                        parameters.Add("pin", this.            pin
);
                                                                                                        parameters.Add("isVenderReply", this.            isVenderReply
);
                                                                                                        parameters.Add("cid", this.            cid
);
                                                                                                        parameters.Add("orderIds", this.            orderIds
);
                                                                                                        parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                                                        parameters.Add("open_id_buyer", this.                                                                                                                    openIdBuyer
);
                                                                            }
    }
}





        
 

