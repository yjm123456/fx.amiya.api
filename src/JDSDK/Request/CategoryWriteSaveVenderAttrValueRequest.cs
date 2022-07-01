using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CategoryWriteSaveVenderAttrValueRequest : JdRequestBase<CategoryWriteSaveVenderAttrValueResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                               public  		Nullable<long>
              valueId
 {get; set;}
                                                          
                                                          public  		string
              attValue
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              attributeId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              categoryId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              indexId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  key {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  value {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.category.write.saveVenderAttrValue";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                                                        parameters.Add("valueId", this.            valueId
);
                                                                                                        parameters.Add("attValue", this.            attValue
);
                                                                                                        parameters.Add("attributeId", this.            attributeId
);
                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                        parameters.Add("indexId", this.            indexId
);
                                                                                                                                                                                        parameters.Add("key", this.            key
);
                                                                                                        parameters.Add("value", this.            value
);
                                                                                                                            }
    }
}





        
 

