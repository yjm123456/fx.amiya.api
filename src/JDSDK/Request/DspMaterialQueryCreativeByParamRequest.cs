using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspMaterialQueryCreativeByParamRequest : JdRequestBase<DspMaterialQueryCreativeByParamResponse>
    {
                                                                                                                   public  		Nullable<int>
              page
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pagesize
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dsp.material.queryCreativeByParam";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("page", this.            page
);
                                                                                                        parameters.Add("pagesize", this.            pagesize
);
                                                    }
    }
}





        
 

