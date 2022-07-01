using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsOutboundRequest : JdRequestBase<DropshipDpsOutboundResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              customOrderId
 {get; set;}
                                                          
                                                          public  		string
              memoByVendor
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              isJdexpress
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              addressId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dropship.dps.outbound";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("customOrderId", this.            customOrderId
);
                                                                                                        parameters.Add("memoByVendor", this.            memoByVendor
);
                                                                                                        parameters.Add("isJdexpress", this.            isJdexpress
);
                                                                                                        parameters.Add("addressId", this.            addressId
);
                                                                            }
    }
}





        
 

