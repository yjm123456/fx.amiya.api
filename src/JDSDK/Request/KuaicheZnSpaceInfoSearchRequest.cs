using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class KuaicheZnSpaceInfoSearchRequest : JdRequestBase<KuaicheZnSpaceInfoSearchResponse>
    {
                                                                                  public  		Nullable<long>
                                                                                      pageId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.kuaiche.zn.space.info.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("page_id", this.                                                                                    pageId
);
                                                    }
    }
}





        
 

