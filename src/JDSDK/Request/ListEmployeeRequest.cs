using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class ListEmployeeRequest : JdRequestBase<ListEmployeeResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		string
              phone
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              employeeId
 {get; set;}
                                                          
                                                          public  		string
              pageNum
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.listEmployee";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                        parameters.Add("employeeId", this.            employeeId
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                            }
    }
}





        
 

