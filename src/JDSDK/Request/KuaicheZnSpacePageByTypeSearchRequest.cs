using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnSpacePageByTypeSearchRequest : JdRequestBase<KuaicheZnSpacePageByTypeSearchResponse>
    {
                                                                                  public  		Nullable<int>
              type
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.space.page.by.type.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("type", this.            type
);
                                                    }
    }
}





        
 

