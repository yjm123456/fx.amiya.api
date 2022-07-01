using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoTransportReverseLasWaybillRequest : JdRequestBase<EclpCoTransportReverseLasWaybillResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              salePlatform
 {get; set;}
                                                          
                                                          public  		string
              customerPin
 {get; set;}
                                                          
                                                          public  		string
              associateSoNo
 {get; set;}
                                                          
                                                          public  		string
              senderName
 {get; set;}
                                                          
                                                          public  		string
              senderMobile
 {get; set;}
                                                          
                                                          public  		string
              senderPhone
 {get; set;}
                                                          
                                                          public  		string
              senderAddress
 {get; set;}
                                                          
                                                          public  		string
              receiverName
 {get; set;}
                                                          
                                                          public  		string
              receiverMobile
 {get; set;}
                                                          
                                                          public  		string
              receiverPhone
 {get; set;}
                                                          
                                                          public  		string
              receiverAddress
 {get; set;}
                                                          
                                                          public  		string
              isFragile
 {get; set;}
                                                          
                                                          public  		string
              pickupReturnReason
 {get; set;}
                                                          
                                                          public  		string
              isGuarantee
 {get; set;}
                                                          
                                                          public  		string
              guaranteeValue
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  weight {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  length {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  width {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  height {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  packageName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  packageQty {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productSku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lasDisassemble {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lasBale {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.co.transportReverseLasWaybill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("salePlatform", this.            salePlatform
);
                                                                                                        parameters.Add("customerPin", this.            customerPin
);
                                                                                                        parameters.Add("associateSoNo", this.            associateSoNo
);
                                                                                                        parameters.Add("senderName", this.            senderName
);
                                                                                                        parameters.Add("senderMobile", this.            senderMobile
);
                                                                                                        parameters.Add("senderPhone", this.            senderPhone
);
                                                                                                        parameters.Add("senderAddress", this.            senderAddress
);
                                                                                                        parameters.Add("receiverName", this.            receiverName
);
                                                                                                        parameters.Add("receiverMobile", this.            receiverMobile
);
                                                                                                        parameters.Add("receiverPhone", this.            receiverPhone
);
                                                                                                        parameters.Add("receiverAddress", this.            receiverAddress
);
                                                                                                        parameters.Add("isFragile", this.            isFragile
);
                                                                                                        parameters.Add("pickupReturnReason", this.            pickupReturnReason
);
                                                                                                        parameters.Add("isGuarantee", this.            isGuarantee
);
                                                                                                        parameters.Add("guaranteeValue", this.            guaranteeValue
);
                                                                                                                                                                                                                parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("length", this.            length
);
                                                                                                        parameters.Add("width", this.            width
);
                                                                                                        parameters.Add("height", this.            height
);
                                                                                                        parameters.Add("packageName", this.            packageName
);
                                                                                                        parameters.Add("packageQty", this.            packageQty
);
                                                                                                        parameters.Add("productSku", this.            productSku
);
                                                                                                        parameters.Add("lasDisassemble", this.            lasDisassemble
);
                                                                                                        parameters.Add("lasBale", this.            lasBale
);
                                                                                                                                                    }
    }
}





        
 

