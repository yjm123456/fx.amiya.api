using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscAuditDoorRenewRequest : JdRequestBase<AscAuditDoorRenewResponse>
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
              appendPickware
 {get; set;}
                                                          
                                                                                                                      public  		string
              pickupContactName
 {get; set;}
                                                          
                                                          public  		string
              pickupContactTel
 {get; set;}
                                                          
                                                          public  		string
              pickupContactMobile
 {get; set;}
                                                          
                                                          public  		string
              pickupZipcode
 {get; set;}
                                                          
                                                          public  		string
              pickupProvince
 {get; set;}
                                                          
                                                          public  		string
              pickupCity
 {get; set;}
                                                          
                                                          public  		string
              pickupCounty
 {get; set;}
                                                          
                                                          public  		string
              pickupVillage
 {get; set;}
                                                          
                                                          public  		string
              pickupDetailAddress
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
                                                          
                                                                                           public  		Nullable<int>
              returnAddressType
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
                                                          
                                                          public  		Nullable<int>
              deliveryCenterId
 {get; set;}
                                                          
                                                          public  		string
              deliveryCenterName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              storeId
 {get; set;}
                                                          
                                                          public  		string
              freightAmount
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  wareName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  wareNum {get; set; }
                                                                                                                                                                                                public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.audit.doorRenew";}
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
                                                                                                        parameters.Add("appendPickware", this.            appendPickware
);
                                                                                                                                                parameters.Add("pickupContactName", this.            pickupContactName
);
                                                                                                        parameters.Add("pickupContactTel", this.            pickupContactTel
);
                                                                                                        parameters.Add("pickupContactMobile", this.            pickupContactMobile
);
                                                                                                        parameters.Add("pickupZipcode", this.            pickupZipcode
);
                                                                                                        parameters.Add("pickupProvince", this.            pickupProvince
);
                                                                                                        parameters.Add("pickupCity", this.            pickupCity
);
                                                                                                        parameters.Add("pickupCounty", this.            pickupCounty
);
                                                                                                        parameters.Add("pickupVillage", this.            pickupVillage
);
                                                                                                        parameters.Add("pickupDetailAddress", this.            pickupDetailAddress
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
                                                                                                                                parameters.Add("returnAddressType", this.            returnAddressType
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
                                                                                                        parameters.Add("deliveryCenterId", this.            deliveryCenterId
);
                                                                                                        parameters.Add("deliveryCenterName", this.            deliveryCenterName
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                        parameters.Add("freightAmount", this.            freightAmount
);
                                                                                                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("wareName", this.            wareName
);
                                                                                                        parameters.Add("wareNum", this.            wareNum
);
                                                                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

