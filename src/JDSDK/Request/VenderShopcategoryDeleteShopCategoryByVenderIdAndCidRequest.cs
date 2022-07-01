using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VenderShopcategoryDeleteShopCategoryByVenderIdAndCidRequest : JdRequestBase<VenderShopcategoryDeleteShopCategoryByVenderIdAndCidResponse>
    {
                                                                                                                   public  		Nullable<long>
              cid
 {get; set;}
                                                          
                                                                                                                                                                                                            public override string ApiName
            {
                get{return "jingdong.vender.shopcategory.deleteShopCategoryByVenderIdAndCid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("cid", this.            cid
);
                                                                                                                                                                                                                                                                    }
    }
}





        
 

