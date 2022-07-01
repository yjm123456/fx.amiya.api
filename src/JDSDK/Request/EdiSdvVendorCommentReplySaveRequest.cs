using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiSdvVendorCommentReplySaveRequest : JdRequestBase<EdiSdvVendorCommentReplySaveResponse>
    {
                                                                                                                                              public  		string
              username
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              commentId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              parentReplyId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              targetReplyId
 {get; set;}
                                                          
                                                          public  		string
              content
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              venderId
 {get; set;}
                                                          
                                                                                           public  		string
              ip
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clientType
 {get; set;}
                                                          
                                                          public  		string
              uuid
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.edi.sdv.vendor.comment.reply.save";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("username", this.            username
);
                                                                                                        parameters.Add("commentId", this.            commentId
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("parentReplyId", this.            parentReplyId
);
                                                                                                        parameters.Add("targetReplyId", this.            targetReplyId
);
                                                                                                        parameters.Add("content", this.            content
);
                                                                                                        parameters.Add("venderId", this.            venderId
);
                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("clientType", this.            clientType
);
                                                                                                        parameters.Add("uuid", this.            uuid
);
                                                                            }
    }
}





        
 

