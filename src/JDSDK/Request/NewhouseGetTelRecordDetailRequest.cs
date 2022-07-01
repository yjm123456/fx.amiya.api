using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseGetTelRecordDetailRequest : JdRequestBase<NewhouseGetTelRecordDetailResponse>
    {
                                                                                                                                              public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              clueId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.getTelRecordDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                                                                        parameters.Add("clueId", this.            clueId
);
                                                                            }
    }
}





        
 

