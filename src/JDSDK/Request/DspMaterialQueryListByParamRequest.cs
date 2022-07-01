using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspMaterialQueryListByParamRequest : JdRequestBase<DspMaterialQueryListByParamResponse>
    {
                                                                                  public  		Nullable<int>
              effective
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.material.queryListByParam";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("effective", this.            effective
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                    }
    }
}





        
 

