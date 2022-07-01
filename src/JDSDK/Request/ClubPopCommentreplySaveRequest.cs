using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ClubPopCommentreplySaveRequest : JdRequestBase<ClubPopCommentreplySaveResponse>
    {
                                                                                                                                              public  		string
              commentId
 {get; set;}
                                                          
                                                          public  		string
              content
 {get; set;}
                                                          
                                                                                           public  		string
              replyId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.club.pop.commentreply.save";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("commentId", this.            commentId
);
                                                                                                        parameters.Add("content", this.            content
);
                                                                                                                                                        parameters.Add("replyId", this.            replyId
);
                                                                                                                            }
    }
}





        
 

