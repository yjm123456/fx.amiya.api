using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiInventorySendRequest : JdRequestBase<EdiInventorySendResponse>
    {
                                                                                                                                              public  		string
              vendorCode
 {get; set;}
                                                          
                                                          public  		string
              vendorName
 {get; set;}
                                                          
                                                          public  		string
              vendorProductId
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              inventoryDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              totalQuantity
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              estimateDate
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              totalEstimateQuantity
 {get; set;}
                                                          
                                                          public  		string
              costPrice
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                              		public  		string
  storeId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  storeName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quantity {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  estimateQuantity {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.edi.inventory.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                        parameters.Add("vendorProductId", this.            vendorProductId
);
                                                                                                        parameters.Add("inventoryDate", this.            inventoryDate
);
                                                                                                        parameters.Add("totalQuantity", this.            totalQuantity
);
                                                                                                        parameters.Add("estimateDate", this.            estimateDate
);
                                                                                                        parameters.Add("totalEstimateQuantity", this.            totalEstimateQuantity
);
                                                                                                        parameters.Add("costPrice", this.            costPrice
);
                                                                                                                                                                                                                                                                parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("storeName", this.            storeName
);
                                                                                                        parameters.Add("quantity", this.            quantity
);
                                                                                                        parameters.Add("estimateQuantity", this.            estimateQuantity
);
                                                                                                    }
    }
}





        
 

