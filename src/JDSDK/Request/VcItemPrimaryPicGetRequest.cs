using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemPrimaryPicGetRequest : JdRequestBase<VcItemPrimaryPicGetResponse>
    {
                                                                                                                   public  		string
                                                                                      wareId
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.vc.item.primaryPic.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("ware_id", this.                                                                                    wareId
);
                                                    }
    }
}





        
 

