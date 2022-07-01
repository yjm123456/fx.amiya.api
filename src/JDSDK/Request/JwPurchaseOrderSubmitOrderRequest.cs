using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JwPurchaseOrderSubmitOrderRequest : JdRequestBase<JwPurchaseOrderSubmitOrderResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                		public  		string
  sku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                            public  		string
              addressLevel1Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel2Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel3Id
 {get; set;}
                                                          
                                                          public  		string
              addressLevel4Id
 {get; set;}
                                                          
                                                          public  		string
              addressDetail
 {get; set;}
                                                          
                                                          public  		string
              phone
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		string
              idCard
 {get; set;}
                                                          
                                                                                                                                                       public  		Nullable<int>
              invoiceType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              billingType
 {get; set;}
                                                          
                                                                                           public  	    Nullable<bool>
              autoDeductRebate
 {get; set;}
                                                          
                                                          public  		string
              rebate
 {get; set;}
                                                          
                                                          public  		string
              clientId
 {get; set;}
                                                          
                                                          public  		string
              clientBusinessNo
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                                                                               public override string ApiName
            {
                get{return "jingdong.jw.purchase.order.submitOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                        parameters.Add("sku", this.            sku
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                                                                                                                parameters.Add("addressLevel1Id", this.            addressLevel1Id
);
                                                                                                        parameters.Add("addressLevel2Id", this.            addressLevel2Id
);
                                                                                                        parameters.Add("addressLevel3Id", this.            addressLevel3Id
);
                                                                                                        parameters.Add("addressLevel4Id", this.            addressLevel4Id
);
                                                                                                        parameters.Add("addressDetail", this.            addressDetail
);
                                                                                                        parameters.Add("phone", this.            phone
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("idCard", this.            idCard
);
                                                                                                                                                                        parameters.Add("invoiceType", this.            invoiceType
);
                                                                                                        parameters.Add("billingType", this.            billingType
);
                                                                                                                                parameters.Add("autoDeductRebate", this.            autoDeductRebate
);
                                                                                                        parameters.Add("rebate", this.            rebate
);
                                                                                                        parameters.Add("clientId", this.            clientId
);
                                                                                                        parameters.Add("clientBusinessNo", this.            clientBusinessNo
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                                                                                            }
    }
}





        
 

