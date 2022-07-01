using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspMaterialQueryMaterialByIdRequest : JdRequestBase<DspMaterialQueryMaterialByIdResponse>
    {
                                                                                  public  		Nullable<long>
              materialId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.material.queryMaterialById";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("materialId", this.            materialId
);
                                                                                                    }
    }
}





        
 

