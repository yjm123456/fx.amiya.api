using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EtmsPackageUpdateRequest : JdRequestBase<EtmsPackageUpdateResponse>
    {
                                                                                                                                              public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              deliveryId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packageCount
 {get; set;}
                                                          
                                                                                      public  		string
              boxCodeList
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.etms.package.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("deliveryId", this.            deliveryId
);
                                                                                                        parameters.Add("packageCount", this.            packageCount
);
                                                                                                        parameters.Add("boxCodeList", this.            boxCodeList
);
                                                                                                                            }
    }
}





        
 

