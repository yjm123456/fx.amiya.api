using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkcunitStatusUpdateRequest : JdRequestBase<DspAdkcunitStatusUpdateResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  adGroupId {get; set; }
                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.dsp.adkcunit.status.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("status", this.            status
);
                                                                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                                                    }
    }
}





        
 

