using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CategoryReadFindValuesByAttrIdRequest : JdRequestBase<CategoryReadFindValuesByAttrIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              categoryAttrId
 {get; set;}
                                                          
                                                                                      public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.category.read.findValuesByAttrId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("categoryAttrId", this.            categoryAttrId
);
                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

