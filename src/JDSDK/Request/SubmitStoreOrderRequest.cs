using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SubmitStoreOrderRequest : JdRequestBase<SubmitStoreOrderResponse>
    {
                                                                                                                                                                               public  		string
              pin
 {get; set;}
                                                          
                                                          public  		string
              code
 {get; set;}
                                                          
                                                          public  		string
              address
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              provinceId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              cityId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              countryId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              townId
 {get; set;}
                                                          
                                                          public  		string
              receiver
 {get; set;}
                                                          
                                                          public  		string
              mobile
 {get; set;}
                                                          
                                                          public  		string
              email
 {get; set;}
                                                          
                                                          public  		string
              phone
 {get; set;}
                                                          
                                                          public  		string
              totalPrice
 {get; set;}
                                                          
                                                          public  		string
              salesPin
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		string
              deliveryType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		Nullable<long>
  categoryId1 {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		Nullable<long>
  categoryId2 {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		Nullable<long>
  categoryId3 {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		Nullable<int>
  purchaseNum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuPrice {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.submitStoreOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("pin", this.            pin
);
                                                                                                        parameters.Add("code", this.            code
);
                                                                                                        parameters.Add("address", this.            address
);
                                                                                                        parameters.Add("provinceId", this.            provinceId
);
                                                                                                        parameters.Add("cityId", this.            cityId
);
                                                                                                        parameters.Add("countryId", this.            countryId
);
                                                                                                        parameters.Add("townId", this.            townId
);
                                                                                                        parameters.Add("receiver", this.            receiver
);
                                                                                                        parameters.Add("mobile", this.            mobile
);
                                                                                                        parameters.Add("email", this.            email
);
                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                        parameters.Add("totalPrice", this.            totalPrice
);
                                                                                                        parameters.Add("salesPin", this.            salesPin
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("deliveryType", this.            deliveryType
);
                                                                                                                                                                                        parameters.Add("categoryId1", this.            categoryId1
);
                                                                                                        parameters.Add("categoryId2", this.            categoryId2
);
                                                                                                        parameters.Add("categoryId3", this.            categoryId3
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("skuName", this.            skuName
);
                                                                                                        parameters.Add("purchaseNum", this.            purchaseNum
);
                                                                                                        parameters.Add("skuPrice", this.            skuPrice
);
                                                                                                                            }
    }
}





        
 

