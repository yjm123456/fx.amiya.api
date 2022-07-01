using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkcunitAreadirectionUpdateRequest : JdRequestBase<DspAdkcunitAreadirectionUpdateResponse>
    {
                                                                                  public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		string
              areaId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.adkcunit.areadirection.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("areaId", this.            areaId
);
                                                                                                                                                    }
    }
}





        
 

