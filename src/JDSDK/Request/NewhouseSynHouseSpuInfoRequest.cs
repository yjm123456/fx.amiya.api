using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseSynHouseSpuInfoRequest : JdRequestBase<NewhouseSynHouseSpuInfoResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.synHouseSpuInfo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                            }
    }
}





        
 

