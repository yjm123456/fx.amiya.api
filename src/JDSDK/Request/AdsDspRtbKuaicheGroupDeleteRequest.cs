using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheGroupDeleteRequest : JdRequestBase<AdsDspRtbKuaicheGroupDeleteResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                		public  		string
  ids {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.group.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

