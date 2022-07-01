using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiSsSendRequest : JdRequestBase<EdiSsSendResponse>
    {
                                                                                                                                              public  		string
              vendorName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		string
              purchaseOrderCode
 {get; set;}
                                                          
                                                          public  		string
              jdShipmentNumber
 {get; set;}
                                                          
                                                                                           public  		string
              vendorCode
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  vendorShipmentNumber {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  serialNumber {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  vendorProductId {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.edi.ss.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("purchaseOrderCode", this.            purchaseOrderCode
);
                                                                                                        parameters.Add("jdShipmentNumber", this.            jdShipmentNumber
);
                                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                                                                                                                                parameters.Add("vendorShipmentNumber", this.            vendorShipmentNumber
);
                                                                                                        parameters.Add("serialNumber", this.            serialNumber
);
                                                                                                        parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("vendorProductId", this.            vendorProductId
);
                                                                                                    }
    }
}





        
 

