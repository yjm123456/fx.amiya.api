using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemSpuTemplateGetRequest : JdRequestBase<VcItemSpuTemplateGetResponse>
    {
                                                                                  public  		string
              cid3
 {get; set;}
                                                          
                                                          public  		string
                                                                                      brandId
 {get; set;}
                                                                                                                                  
                                                          public  		string
              model
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.vc.item.spuTemplate.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("cid3", this.            cid3
);
                                                                                                        parameters.Add("brand_id", this.                                                                                    brandId
);
                                                                                                        parameters.Add("model", this.            model
);
                                                    }
    }
}





        
 

