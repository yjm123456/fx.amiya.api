using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchDeleteDmpRequest : JdRequestBase<AdsDspRtbTpBatchDeleteDmpResponse>
    {
                                                                                  public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  ids {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchDeleteDmp";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

