using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcCampainDeleteRequest : JdRequestBase<DspKcCampainDeleteResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  compaignId {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.dsp.kc.campain.delete";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                parameters.Add("compaignId", this.            compaignId
);
                                                                                                    }
    }
}





        
 

