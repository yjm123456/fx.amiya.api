using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class PopInvoiceSelfApplyRequest : JdRequestBase<PopInvoiceSelfApplyResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  productId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  num {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  price {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  spec {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  unit {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  taxRate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  taxCategroyCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isTaxDiscount {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  taxDiscountContent {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  zeroTax {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  deductions {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imei {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  discount {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  freight {get; set; }
                                                                                                                                                                                                                                                            public  		string
              orderId
 {get; set;}
                                                          
                                                                                           public  		string
              receiverTaxNo
 {get; set;}
                                                          
                                                          public  		string
              receiverName
 {get; set;}
                                                          
                                                          public  		string
              invoiceCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              invoiceNo
 {get; set;}
                                                          
                                                          public  		string
              ivcTitle
 {get; set;}
                                                          
                                                          public  		string
              totalPrice
 {get; set;}
                                                          
                                                          public  		string
              invoiceTime
 {get; set;}
                                                          
                                                          public  		string
              pdfInfo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              ivcContentType
 {get; set;}
                                                          
                                                          public  		string
              ivcContentName
 {get; set;}
                                                          
                                                          public  		string
              eiRemark
 {get; set;}
                                                          
                                                          public  		string
              receiverAddress
 {get; set;}
                                                          
                                                          public  		string
              receiverPhone
 {get; set;}
                                                          
                                                          public  		string
              receiverBankName
 {get; set;}
                                                          
                                                          public  		string
              receiverBankAccount
 {get; set;}
                                                          
                                                          public  		string
              drawer
 {get; set;}
                                                          
                                                          public  		string
              payee
 {get; set;}
                                                          
                                                          public  		string
              consumerAddress
 {get; set;}
                                                          
                                                          public  		string
              consumerPhone
 {get; set;}
                                                          
                                                          public  		string
              consumerBankName
 {get; set;}
                                                          
                                                          public  		string
              consumerBankAccount
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.pop.invoice.self.apply";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("productId", this.            productId
);
                                                                                                        parameters.Add("productName", this.            productName
);
                                                                                                        parameters.Add("num", this.            num
);
                                                                                                        parameters.Add("price", this.            price
);
                                                                                                        parameters.Add("spec", this.            spec
);
                                                                                                        parameters.Add("unit", this.            unit
);
                                                                                                        parameters.Add("taxRate", this.            taxRate
);
                                                                                                        parameters.Add("taxCategroyCode", this.            taxCategroyCode
);
                                                                                                        parameters.Add("isTaxDiscount", this.            isTaxDiscount
);
                                                                                                        parameters.Add("taxDiscountContent", this.            taxDiscountContent
);
                                                                                                        parameters.Add("zeroTax", this.            zeroTax
);
                                                                                                        parameters.Add("deductions", this.            deductions
);
                                                                                                        parameters.Add("imei", this.            imei
);
                                                                                                        parameters.Add("discount", this.            discount
);
                                                                                                        parameters.Add("freight", this.            freight
);
                                                                                                                                                                                                parameters.Add("orderId", this.            orderId
);
                                                                                                                                                        parameters.Add("receiverTaxNo", this.            receiverTaxNo
);
                                                                                                        parameters.Add("receiverName", this.            receiverName
);
                                                                                                        parameters.Add("invoiceCode", this.            invoiceCode
);
                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                                                        parameters.Add("ivcTitle", this.            ivcTitle
);
                                                                                                        parameters.Add("totalPrice", this.            totalPrice
);
                                                                                                        parameters.Add("invoiceTime", this.            invoiceTime
);
                                                                                                        parameters.Add("pdfInfo", this.            pdfInfo
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("ivcContentType", this.            ivcContentType
);
                                                                                                        parameters.Add("ivcContentName", this.            ivcContentName
);
                                                                                                        parameters.Add("eiRemark", this.            eiRemark
);
                                                                                                        parameters.Add("receiverAddress", this.            receiverAddress
);
                                                                                                        parameters.Add("receiverPhone", this.            receiverPhone
);
                                                                                                        parameters.Add("receiverBankName", this.            receiverBankName
);
                                                                                                        parameters.Add("receiverBankAccount", this.            receiverBankAccount
);
                                                                                                        parameters.Add("drawer", this.            drawer
);
                                                                                                        parameters.Add("payee", this.            payee
);
                                                                                                        parameters.Add("consumerAddress", this.            consumerAddress
);
                                                                                                        parameters.Add("consumerPhone", this.            consumerPhone
);
                                                                                                        parameters.Add("consumerBankName", this.            consumerBankName
);
                                                                                                        parameters.Add("consumerBankAccount", this.            consumerBankAccount
);
                                                                            }
    }
}





        
 

