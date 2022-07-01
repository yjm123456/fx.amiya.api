using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ImgzoneCategoryAddRequest : JdRequestBase<ImgzoneCategoryAddResponse>
    {
                                                                                                                   public  		string
                                                                                      cateName
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                                                      parentCateId
 {get; set;}
                                                                                                                                                          
            public override string ApiName
            {
                get{return "jingdong.imgzone.category.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("cate_name", this.                                                                                    cateName
);
                                                                                                        parameters.Add("parent_cate_id", this.                                                                                                                    parentCateId
);
                                                    }
    }
}





        
 

