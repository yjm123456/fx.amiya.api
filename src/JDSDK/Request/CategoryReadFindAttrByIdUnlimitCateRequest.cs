using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CategoryReadFindAttrByIdUnlimitCateRequest : JdRequestBase<CategoryReadFindAttrByIdUnlimitCateResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              attrId
 {get; set;}
                                                          
                                                                                      public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.category.read.findAttrByIdUnlimitCate";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("attrId", this.            attrId
);
                                                                                                        parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

