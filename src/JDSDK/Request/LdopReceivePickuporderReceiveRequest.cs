using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopReceivePickuporderReceiveRequest : JdRequestBase<LdopReceivePickuporderReceiveResponse>
    {
                                                                                                                                              public  		string
              pickupAddress
 {get; set;}
                                                          
                                                          public  		string
              pickupName
 {get; set;}
                                                          
                                                          public  		string
              pickupTel
 {get; set;}
                                                          
                                                          public  		string
              customerTel
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                                                           public  		string
              backAddress
 {get; set;}
                                                          
                                                          public  		string
              customerContract
 {get; set;}
                                                          
                                                          public  		string
              desp
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              weight
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              volume
 {get; set;}
                                                          
                                                          public  		string
              valueAddService
 {get; set;}
                                                          
                                                          public  	    Nullable<bool>
              guaranteeValue
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              guaranteeValueAmount
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              pickupStartTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              pickupEndTime
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  productId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productCount {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  snCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuAddService {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuCheckOutShapes {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuCheckAttachFile {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              promiseTimeType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              guaranteeSettleType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packingSettleType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              freightSettleType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              allowedRepeatOrderType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.receive.pickuporder.receive";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("pickupAddress", this.            pickupAddress
);
                                                                                                        parameters.Add("pickupName", this.            pickupName
);
                                                                                                        parameters.Add("pickupTel", this.            pickupTel
);
                                                                                                        parameters.Add("customerTel", this.            customerTel
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                                                                        parameters.Add("backAddress", this.            backAddress
);
                                                                                                        parameters.Add("customerContract", this.            customerContract
);
                                                                                                        parameters.Add("desp", this.            desp
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("volume", this.            volume
);
                                                                                                        parameters.Add("valueAddService", this.            valueAddService
);
                                                                                                        parameters.Add("guaranteeValue", this.            guaranteeValue
);
                                                                                                        parameters.Add("guaranteeValueAmount", this.            guaranteeValueAmount
);
                                                                                                        parameters.Add("pickupStartTime", this.            pickupStartTime
);
                                                                                                        parameters.Add("pickupEndTime", this.            pickupEndTime
);
                                                                                                                                                                                        parameters.Add("productId", this.            productId
);
                                                                                                        parameters.Add("productName", this.            productName
);
                                                                                                        parameters.Add("productCount", this.            productCount
);
                                                                                                        parameters.Add("snCode", this.            snCode
);
                                                                                                        parameters.Add("skuAddService", this.            skuAddService
);
                                                                                                        parameters.Add("skuCheckOutShapes", this.            skuCheckOutShapes
);
                                                                                                        parameters.Add("skuCheckAttachFile", this.            skuCheckAttachFile
);
                                                                                                                                                        parameters.Add("promiseTimeType", this.            promiseTimeType
);
                                                                                                        parameters.Add("guaranteeSettleType", this.            guaranteeSettleType
);
                                                                                                        parameters.Add("packingSettleType", this.            packingSettleType
);
                                                                                                        parameters.Add("freightSettleType", this.            freightSettleType
);
                                                                                                        parameters.Add("allowedRepeatOrderType", this.            allowedRepeatOrderType
);
                                                                            }
    }
}





        
 

