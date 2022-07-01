using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareProductsortGetRequest : JdRequestBase<WareProductsortGetResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   		public  		string
  productSortIds {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.ware.productsort.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("product_sort_ids", this.                                                                                                                    productSortIds
);
                                                                            }
    }
}





        
 

