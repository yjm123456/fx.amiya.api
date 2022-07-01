using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TemplateWriteBindWareRequest : JdRequestBase<TemplateWriteBindWareResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              templateId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              wareId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.template.write.bindWare";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("templateId", this.            templateId
);
                                                                                                        parameters.Add("wareId", this.            wareId
);
                                                    }
    }
}





        
 

