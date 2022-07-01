using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class UpdateEntityStoreRequest : JdRequestBase<UpdateEntityStoreResponse>
    {
                                                                                                                                              public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                                                           public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              addCode
 {get; set;}
                                                          
                                                          public  		string
              addName
 {get; set;}
                                                          
                                                          public  		string
              coordinate
 {get; set;}
                                                          
                                                          public  		string
              phone
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  groupId {get; set; }
                                                                                                                                                                                                public  		string
              customerId
 {get; set;}
                                                          
                                                          public  		string
              categoryName
 {get; set;}
                                                          
                                                          public  		string
              extendJson
 {get; set;}
                                                          
                                                          public  		string
              imageFile
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              addCode4
 {get; set;}
                                                          
                                                          public  		string
              mobile
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              categoryId2
 {get; set;}
                                                          
                                                          public  		string
              slogan
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.updateEntityStore";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("addCode", this.            addCode
);
                                                                                                        parameters.Add("addName", this.            addName
);
                                                                                                        parameters.Add("coordinate", this.            coordinate
);
                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                                                                parameters.Add("groupId", this.            groupId
);
                                                                                                                                parameters.Add("customerId", this.            customerId
);
                                                                                                        parameters.Add("categoryName", this.            categoryName
);
                                                                                                        parameters.Add("extendJson", this.            extendJson
);
                                                                                                        parameters.Add("imageFile", this.            imageFile
);
                                                                                                        parameters.Add("addCode4", this.            addCode4
);
                                                                                                        parameters.Add("mobile", this.            mobile
);
                                                                                                        parameters.Add("categoryId2", this.            categoryId2
);
                                                                                                        parameters.Add("slogan", this.            slogan
);
                                                                            }
    }
}





        
 

