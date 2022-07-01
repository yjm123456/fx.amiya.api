using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CategoryReadFindByPIdRequest : JdRequestBase<CategoryReadFindByPIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              parentCid
 {get; set;}
                                                          
                                                                                      public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.category.read.findByPId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("parentCid", this.            parentCid
);
                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

