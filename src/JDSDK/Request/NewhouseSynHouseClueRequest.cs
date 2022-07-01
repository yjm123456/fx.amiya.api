using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseSynHouseClueRequest : JdRequestBase<NewhouseSynHouseClueResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              clueId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.synHouseClue";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("clueId", this.            clueId
);
                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                            }
    }
}





        
 

