using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EdiVaSendRequest : JdRequestBase<EdiVaSendResponse>
    {
                                                                                                                                              public  		string
              vendorName
 {get; set;}
                                                          
                                                          public  		string
              billNo
 {get; set;}
                                                          
                                                          public  		string
              businessType
 {get; set;}
                                                          
                                                          public  		string
              totalAmount
 {get; set;}
                                                          
                                                                                           public  		string
              vendorCode
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  settleNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  payableAccountId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  billType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  verificationBillNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  billDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  poNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  soNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  amount {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  memo {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  invoiceNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  invoiceCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  taxAmount {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.edi.va.send";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("vendorName", this.            vendorName
);
                                                                                                        parameters.Add("billNo", this.            billNo
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                        parameters.Add("totalAmount", this.            totalAmount
);
                                                                                                                                                        parameters.Add("vendorCode", this.            vendorCode
);
                                                                                                                                                                                                                parameters.Add("settleNo", this.            settleNo
);
                                                                                                        parameters.Add("payableAccountId", this.            payableAccountId
);
                                                                                                        parameters.Add("billType", this.            billType
);
                                                                                                        parameters.Add("verificationBillNo", this.            verificationBillNo
);
                                                                                                        parameters.Add("billDate", this.            billDate
);
                                                                                                        parameters.Add("poNo", this.            poNo
);
                                                                                                        parameters.Add("soNo", this.            soNo
);
                                                                                                        parameters.Add("amount", this.            amount
);
                                                                                                        parameters.Add("memo", this.            memo
);
                                                                                                                                                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                                                        parameters.Add("invoiceCode", this.            invoiceCode
);
                                                                                                        parameters.Add("taxAmount", this.            taxAmount
);
                                                                                                    }
    }
}





        
 

