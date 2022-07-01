using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCategoryGetSecondLevelCategoriesRequest : JdRequestBase<EclpCategoryGetSecondLevelCategoriesResponse>
    {
                                                                                                                                              public  		Nullable<long>
              firstCategoryNo
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              secondCategoryNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.category.getSecondLevelCategories";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("firstCategoryNo", this.            firstCategoryNo
);
                                                                                                        parameters.Add("secondCategoryNo", this.            secondCategoryNo
);
                                                                                                                            }
    }
}





        
 

