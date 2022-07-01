using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCategoryGetFirstLevelCategoriesRequest : JdRequestBase<EclpCategoryGetFirstLevelCategoriesResponse>
    {
                                                                     public override string ApiName
            {
                get{return "jingdong.eclp.category.getFirstLevelCategories";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                            }
    }
}





        
 

