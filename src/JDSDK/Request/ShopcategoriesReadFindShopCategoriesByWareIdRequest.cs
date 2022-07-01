using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ShopcategoriesReadFindShopCategoriesByWareIdRequest : JdRequestBase<ShopcategoriesReadFindShopCategoriesByWareIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.shopcategories.read.findShopCategoriesByWareId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                    }
    }
}





        
 

