using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CmpUserApplyChannelRequest : JdRequestBase<CmpUserApplyChannelResponse>
    {
                                                                                                                                              public  		string
              summary
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              id
 {get; set;}
                                                          
                                                                                           public  		string
              nickName
 {get; set;}
                                                          
                                                                                           public  		string
              headPicUrl
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              userSource
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              designerType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.cmp.user.apply.channel";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("summary", this.            summary
);
                                                                                                        parameters.Add("id", this.            id
);
                                                                                                                                                        parameters.Add("nickName", this.            nickName
);
                                                                                                                                                        parameters.Add("headPicUrl", this.            headPicUrl
);
                                                                                                        parameters.Add("userSource", this.            userSource
);
                                                                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("designerType", this.            designerType
);
                                                                            }
    }
}





        
 

