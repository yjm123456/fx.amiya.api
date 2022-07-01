using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CategoryReadFindAttrsByCategoryIdRequest : JdRequestBase<CategoryReadFindAttrsByCategoryIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              cid
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              attributeType
 {get; set;}
                                                          
                                                                                      public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.category.read.findAttrsByCategoryId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("cid", this.            cid
);
                                                                                                        parameters.Add("attributeType", this.            attributeType
);
                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

