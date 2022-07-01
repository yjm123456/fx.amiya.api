using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CategoryReadFindValuesByIdRequest : JdRequestBase<CategoryReadFindValuesByIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              id
 {get; set;}
                                                          
                                                                                      public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.category.read.findValuesById";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("id", this.            id
);
                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

