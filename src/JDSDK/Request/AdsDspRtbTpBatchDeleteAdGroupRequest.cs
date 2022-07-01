using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchDeleteAdGroupRequest : JdRequestBase<AdsDspRtbTpBatchDeleteAdGroupResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  idList {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchDeleteAdGroup";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("idList", this.            idList
);
                                                                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

