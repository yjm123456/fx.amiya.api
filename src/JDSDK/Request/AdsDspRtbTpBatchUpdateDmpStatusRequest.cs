using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbTpBatchUpdateDmpStatusRequest : JdRequestBase<AdsDspRtbTpBatchUpdateDmpStatusResponse>
    {
                                                                                  public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  ids {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              operateType
 {get; set;}
                                                          
                                                                                                                                                                                                                                             public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.tp.batchUpdateDmpStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                parameters.Add("operateType", this.            operateType
);
                                                                                                                                                                                                                                                                                                                    }
    }
}





        
 

