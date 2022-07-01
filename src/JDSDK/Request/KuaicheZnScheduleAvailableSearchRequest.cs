using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnScheduleAvailableSearchRequest : JdRequestBase<KuaicheZnScheduleAvailableSearchResponse>
    {
                                                                                  public  		Nullable<long>
                                                                                      spaceId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.schedule.available.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("space_id", this.                                                                                    spaceId
);
                                                    }
    }
}





        
 

