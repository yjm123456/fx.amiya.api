using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class YunpeiDemandGetRequest : JdRequestBase<YunpeiDemandGetResponse>
    {
                                                                                                                   public  		string
                                                                                      demandSn
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.yunpei.demand.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("demand_sn", this.                                                                                    demandSn
);
                                                    }
    }
}





        
 

