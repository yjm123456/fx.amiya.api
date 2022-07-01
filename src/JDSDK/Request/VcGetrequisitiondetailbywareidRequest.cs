using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcGetrequisitiondetailbywareidRequest : JdRequestBase<VcGetrequisitiondetailbywareidResponse>
    {
                                                                                                                                              public  		Nullable<long>
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      deliverCenterId
 {get; set;}
                                                                                                                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.vc.getrequisitiondetailbywareid";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("deliver_center_id", this.                                                                                                                    deliverCenterId
);
                                                                                                                            }
    }
}





        
 

