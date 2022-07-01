using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspCampainStatusUpdateRequest : JdRequestBase<DspCampainStatusUpdateResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              status
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  id {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.dsp.campain.status.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("status", this.            status
);
                                                                                                                                                                                                                                                parameters.Add("id", this.            id
);
                                                                                                    }
    }
}





        
 

