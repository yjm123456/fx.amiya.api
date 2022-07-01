using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdunitAreaUpdateRequest : JdRequestBase<DspAdunitAreaUpdateResponse>
    {
                                                                                  public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                          public  		string
              areaId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.adunit.area.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("areaId", this.            areaId
);
                                                                                                                                                    }
    }
}





        
 

