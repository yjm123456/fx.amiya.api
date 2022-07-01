using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DeliRecomdCarriersSearchRequest : JdRequestBase<DeliRecomdCarriersSearchResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  sku {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              sendProvinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sendCityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sendCountyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sendTownId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiveProvinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiveCityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiveCountyId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              receiveTownId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.deliRecomdCarriers.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                                                                parameters.Add("sku", this.            sku
);
                                                                                                                                parameters.Add("sendProvinceId", this.            sendProvinceId
);
                                                                                                        parameters.Add("sendCityId", this.            sendCityId
);
                                                                                                        parameters.Add("sendCountyId", this.            sendCountyId
);
                                                                                                        parameters.Add("sendTownId", this.            sendTownId
);
                                                                                                        parameters.Add("receiveProvinceId", this.            receiveProvinceId
);
                                                                                                        parameters.Add("receiveCityId", this.            receiveCityId
);
                                                                                                        parameters.Add("receiveCountyId", this.            receiveCountyId
);
                                                                                                        parameters.Add("receiveTownId", this.            receiveTownId
);
                                                                            }
    }
}





        
 

