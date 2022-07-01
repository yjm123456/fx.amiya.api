using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsSkuUpdateRequest : JdRequestBase<LogisticsSkuUpdateResponse>
    {
                                                                                                                                              public  		string
                                                                                      goodsNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      barCode
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		string
                                                                                      goodsAbbreviation
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      categoryId
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      categoryName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      brandNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      brandName
 {get; set;}
                                                                                                                                  
                                                          public  		string
              format
 {get; set;}
                                                          
                                                          public  		string
              color
 {get; set;}
                                                          
                                                          public  		string
              size
 {get; set;}
                                                          
                                                          public  		string
                                                                                      grossWeight
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      netWeight
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      sizeDefinition
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      suppliersName
 {get; set;}
                                                                                                                                  
                                                          public  		string
              manufacturer
 {get; set;}
                                                          
                                                          public  		string
                                                                                      suppliersNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      productArea
 {get; set;}
                                                                                                                                  
                                                          public  		string
              length
 {get; set;}
                                                          
                                                          public  		string
              width
 {get; set;}
                                                          
                                                          public  		string
              height
 {get; set;}
                                                          
                                                          public  		string
              volume
 {get; set;}
                                                          
                                                          public  		string
                                                                                      isSafe
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      safeDate
 {get; set;}
                                                                                                                                  
                                                                              public override string ApiName
            {
                get{return "jingdong.logistics.sku.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("goods_no", this.                                                                                    goodsNo
);
                                                                                                        parameters.Add("bar_code", this.                                                                                    barCode
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("goods_abbreviation", this.                                                                                    goodsAbbreviation
);
                                                                                                        parameters.Add("category_id", this.                                                                                    categoryId
);
                                                                                                        parameters.Add("category_name", this.                                                                                    categoryName
);
                                                                                                        parameters.Add("brand_no", this.                                                                                    brandNo
);
                                                                                                        parameters.Add("brand_name", this.                                                                                    brandName
);
                                                                                                        parameters.Add("format", this.            format
);
                                                                                                        parameters.Add("color", this.            color
);
                                                                                                        parameters.Add("size", this.            size
);
                                                                                                        parameters.Add("gross_weight", this.                                                                                    grossWeight
);
                                                                                                        parameters.Add("net_weight", this.                                                                                    netWeight
);
                                                                                                        parameters.Add("size_definition", this.                                                                                    sizeDefinition
);
                                                                                                        parameters.Add("suppliers_name", this.                                                                                    suppliersName
);
                                                                                                        parameters.Add("manufacturer", this.            manufacturer
);
                                                                                                        parameters.Add("suppliers_no", this.                                                                                    suppliersNo
);
                                                                                                        parameters.Add("product_area", this.                                                                                    productArea
);
                                                                                                        parameters.Add("length", this.            length
);
                                                                                                        parameters.Add("width", this.            width
);
                                                                                                        parameters.Add("height", this.            height
);
                                                                                                        parameters.Add("volume", this.            volume
);
                                                                                                        parameters.Add("is_safe", this.                                                                                    isSafe
);
                                                                                                        parameters.Add("safe_date", this.                                                                                    safeDate
);
                                                                                                                            }
    }
}





        
 

