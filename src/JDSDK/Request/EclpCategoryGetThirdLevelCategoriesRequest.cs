using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCategoryGetThirdLevelCategoriesRequest : JdRequestBase<EclpCategoryGetThirdLevelCategoriesResponse>
    {
                                                                                                                                              public  		Nullable<long>
              secondCategoryNo
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              thirdCategoryNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.category.getThirdLevelCategories";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("secondCategoryNo", this.            secondCategoryNo
);
                                                                                                        parameters.Add("thirdCategoryNo", this.            thirdCategoryNo
);
                                                                                                                            }
    }
}





        
 

