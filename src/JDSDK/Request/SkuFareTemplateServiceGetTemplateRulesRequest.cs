using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SkuFareTemplateServiceGetTemplateRulesRequest : JdRequestBase<SkuFareTemplateServiceGetTemplateRulesResponse>
    {
                                                                                  public  		string
                                                                                      templateId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.SkuFareTemplateService.getTemplateRules";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("template_id", this.                                                                                    templateId
);
                                                    }
    }
}





        
 

