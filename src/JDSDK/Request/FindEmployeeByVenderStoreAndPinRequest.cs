using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class FindEmployeeByVenderStoreAndPinRequest : JdRequestBase<FindEmployeeByVenderStoreAndPinResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.findEmployeeByVenderStoreAndPin";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                            }
    }
}





        
 

