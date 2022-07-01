using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VenderShopcategoryGetShopCategoryByCidRequest : JdRequestBase<VenderShopcategoryGetShopCategoryByCidResponse>
    {
                                                                                                                   public  		Nullable<long>
              cid
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.vender.shopcategory.getShopCategoryByCid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("cid", this.            cid
);
                                                    }
    }
}





        
 

