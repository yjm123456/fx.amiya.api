using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CategoryReadFindByIdRequest : JdRequestBase<CategoryReadFindByIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              cid
 {get; set;}
                                                          
                                                                                      public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.category.read.findById";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("cid", this.            cid
);
                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

