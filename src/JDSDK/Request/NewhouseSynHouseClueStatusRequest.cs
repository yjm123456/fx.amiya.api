using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class NewhouseSynHouseClueStatusRequest : JdRequestBase<NewhouseSynHouseClueStatusResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              clueId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              clueStatus
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              brokerId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              updateTimeLong
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              channelId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.newhouse.synHouseClueStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("clueId", this.            clueId
);
                                                                                                        parameters.Add("clueStatus", this.            clueStatus
);
                                                                                                        parameters.Add("brokerId", this.            brokerId
);
                                                                                                        parameters.Add("updateTimeLong", this.            updateTimeLong
);
                                                                                                        parameters.Add("channelId", this.            channelId
);
                                                                            }
    }
}





        
 

