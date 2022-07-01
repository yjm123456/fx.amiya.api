using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CmpSkuInfoQuerybyarticleidRequest : JdRequestBase<CmpSkuInfoQuerybyarticleidResponse>
    {
                                                                                  public  		Nullable<int>
              articleId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.cmp.sku.info.querybyarticleid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("articleId", this.            articleId
);
                                                                                                    }
    }
}





        
 

