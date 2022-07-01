using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiAsnSendRequest : JdRequestBase<EdiAsnSendResponse>
    {
                                                                                                                                              public  		string
              purchaseOrderCode
 {get; set;}
                                                          
                                                          public  		string
              deliveryCenterCode
 {get; set;}
                                                          
                                                          public  		string
              deliveryCenterName
 {get; set;}
                                                          
                                                          public  		string
              warehouseCode
 {get; set;}
                                                          
                                                          public  		string
              warehouseName
 {get; set;}
                                                          
                                                          public  		string
              vendorName
 {get; set;}
                                                          
                                                          public  		string
              vendorShipmentCode
 {get; set;}
                                                          
                                                          public  		string
              jdShipmentCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              deleted
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              supposedShipmentTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              supposedArrivedTime
 {get; set;}
                                                          
                                                                                           public  		string
              vendorCode
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  jdSku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  vendorProductId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quantity {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.edi.asn.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("purchaseOrderCode", this.            purchaseOrderCode
);
                                                                                                        parameters.Add("deliveryCenterCode", this.            deliveryCenterCode
);
                                                                                                        parameters.Add("deliveryCenterName", this.            deliveryCenterName
);
                                                                                                        parameters.Add("warehouseCode", this.            warehouseCode
);
                                                                                                        parameters.Add("warehouseName", this.            warehouseName
);
                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                        parameters.Add("vendorShipmentCode", this.            vendorShipmentCode
);
                                                                                                        parameters.Add("jdShipmentCode", this.            jdShipmentCode
);
                                                                                                        parameters.Add("deleted", this.            deleted
);
                                                                                                        parameters.Add("supposedShipmentTime", this.            supposedShipmentTime
);
                                                                                                        parameters.Add("supposedArrivedTime", this.            supposedArrivedTime
);
                                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                                                                                                                                parameters.Add("jdSku", this.            jdSku
);
                                                                                                        parameters.Add("vendorProductId", this.            vendorProductId
);
                                                                                                        parameters.Add("productName", this.            productName
);
                                                                                                        parameters.Add("quantity", this.            quantity
);
                                                                                                    }
    }
}





        
 

