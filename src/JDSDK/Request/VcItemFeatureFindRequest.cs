using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemFeatureFindRequest : JdRequestBase<VcItemFeatureFindResponse>
    {
                                                                                                                   public  		string
              cid3
 {get; set;}
                                                          
                                                          public  		string
                                                                                      wareId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.vc.item.feature.find";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("cid3", this.            cid3
);
                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                    }
    }
}





        
 

