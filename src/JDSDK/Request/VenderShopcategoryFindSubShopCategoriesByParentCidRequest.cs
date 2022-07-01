using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VenderShopcategoryFindSubShopCategoriesByParentCidRequest : JdRequestBase<VenderShopcategoryFindSubShopCategoriesByParentCidResponse>
    {
                                                                                                                   public  		Nullable<long>
                                                                                      parentCid
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.vender.shopcategory.findSubShopCategoriesByParentCid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("parent_cid", this.                                                                                    parentCid
);
                                                    }
    }
}





        
 

