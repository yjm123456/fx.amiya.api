using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitStatusUpdateRequest : JdRequestBase<DspAdunitStatusUpdateResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  ids {get; set; }
                                                                                                                                                                                                                    public override string ApiName
            {
                get{return "jingdong.dsp.adunit.status.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("status", this.            status
);
                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                                    }
    }
}





        
 

