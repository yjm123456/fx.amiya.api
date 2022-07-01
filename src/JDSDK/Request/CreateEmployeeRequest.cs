using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CreateEmployeeRequest : JdRequestBase<CreateEmployeeResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              employeeId
 {get; set;}
                                                          
                                                          public  		string
              phone
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              caccountId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              openId
 {get; set;}
                                                          
                                                          public  		string
              userName
 {get; set;}
                                                          
                                                          public  		string
              imitateIp
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              brandId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              bizId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sourceType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              employeeType
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              venderEmployeeId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.createEmployee";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("employeeId", this.            employeeId
);
                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                        parameters.Add("caccountId", this.            caccountId
);
                                                                                                        parameters.Add("openId", this.            openId
);
                                                                                                        parameters.Add("userName", this.            userName
);
                                                                                                        parameters.Add("imitateIp", this.            imitateIp
);
                                                                                                        parameters.Add("brandId", this.            brandId
);
                                                                                                        parameters.Add("bizId", this.            bizId
);
                                                                                                        parameters.Add("sourceType", this.            sourceType
);
                                                                                                        parameters.Add("employeeType", this.            employeeType
);
                                                                                                        parameters.Add("venderEmployeeId", this.            venderEmployeeId
);
                                                                            }
    }
}





        
 

