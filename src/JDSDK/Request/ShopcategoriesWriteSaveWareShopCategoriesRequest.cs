using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ShopcategoriesWriteSaveWareShopCategoriesRequest : JdRequestBase<ShopcategoriesWriteSaveWareShopCategoriesResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  shopCategory {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.shopcategories.write.saveWareShopCategories";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                                                                parameters.Add("shopCategory", this.            shopCategory
);
                                                                            }
    }
}





        
 

