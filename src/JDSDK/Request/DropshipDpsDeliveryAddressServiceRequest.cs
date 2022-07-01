using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsDeliveryAddressServiceRequest : JdRequestBase<DropshipDpsDeliveryAddressServiceResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              addressId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dropship.dps.deliveryAddressService";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("addressId", this.            addressId
);
                                                                            }
    }
}





        
 

