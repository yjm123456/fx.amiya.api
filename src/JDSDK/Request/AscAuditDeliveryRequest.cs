using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscAuditDeliveryRequest : JdRequestBase<AscAuditDeliveryResponse>
    {
                                                                                                                                                                                                                                                 public  		string
              buId
 {get; set;}
                                                          
                                                          public  		string
              operatePin
 {get; set;}
                                                          
                                                          public  		string
              operateNick
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              serviceId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              orderId
 {get; set;}
                                                          
                                                          public  		string
              approveNotes
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sysVersion
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              approveReasonCid1
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              approveReasonCid2
 {get; set;}
                                                          
                                                                                                                      public  		string
              returnContactName
 {get; set;}
                                                          
                                                          public  		string
              returnContactTel
 {get; set;}
                                                          
                                                          public  		string
              returnContactMobile
 {get; set;}
                                                          
                                                          public  		string
              returnZipcode
 {get; set;}
                                                          
                                                          public  		string
              returnProvince
 {get; set;}
                                                          
                                                          public  		string
              returnCity
 {get; set;}
                                                          
                                                          public  		string
              returnCounty
 {get; set;}
                                                          
                                                          public  		string
              returnVillage
 {get; set;}
                                                          
                                                          public  		string
              returnDetailAddress
 {get; set;}
                                                          
                                                                                                                                                                                   public  		string
              applyDetailIdList
 {get; set;}
                                                          
                                                          public  		string
              invoiceNo
 {get; set;}
                                                          
                                                          public  		string
              invoiceType
 {get; set;}
                                                          
                                                          public  		string
              pickPackage
 {get; set;}
                                                          
                                                          public  		string
              pickDetctPaper
 {get; set;}
                                                          
                                                                                           public  		string
              operateRemark
 {get; set;}
                                                          
                                                          public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.audit.delivery";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                        parameters.Add("buId", this.            buId
);
                                                                                                        parameters.Add("operatePin", this.            operatePin
);
                                                                                                        parameters.Add("operateNick", this.            operateNick
);
                                                                                                        parameters.Add("serviceId", this.            serviceId
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("approveNotes", this.            approveNotes
);
                                                                                                        parameters.Add("sysVersion", this.            sysVersion
);
                                                                                                        parameters.Add("approveReasonCid1", this.            approveReasonCid1
);
                                                                                                        parameters.Add("approveReasonCid2", this.            approveReasonCid2
);
                                                                                                                                                parameters.Add("returnContactName", this.            returnContactName
);
                                                                                                        parameters.Add("returnContactTel", this.            returnContactTel
);
                                                                                                        parameters.Add("returnContactMobile", this.            returnContactMobile
);
                                                                                                        parameters.Add("returnZipcode", this.            returnZipcode
);
                                                                                                        parameters.Add("returnProvince", this.            returnProvince
);
                                                                                                        parameters.Add("returnCity", this.            returnCity
);
                                                                                                        parameters.Add("returnCounty", this.            returnCounty
);
                                                                                                        parameters.Add("returnVillage", this.            returnVillage
);
                                                                                                        parameters.Add("returnDetailAddress", this.            returnDetailAddress
);
                                                                                                                                                                        parameters.Add("applyDetailIdList", this.            applyDetailIdList
);
                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                                                        parameters.Add("invoiceType", this.            invoiceType
);
                                                                                                        parameters.Add("pickPackage", this.            pickPackage
);
                                                                                                        parameters.Add("pickDetctPaper", this.            pickDetctPaper
);
                                                                                                                                parameters.Add("operateRemark", this.            operateRemark
);
                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

