using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AscAuditCompensateRequest : JdRequestBase<AscAuditCompensateResponse>
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
              customerContactName
 {get; set;}
                                                          
                                                          public  		string
              customerContactTel
 {get; set;}
                                                          
                                                          public  		string
              customerContactMobile
 {get; set;}
                                                          
                                                          public  		string
              customerZipcode
 {get; set;}
                                                          
                                                          public  		string
              customerProvince
 {get; set;}
                                                          
                                                          public  		string
              customerCity
 {get; set;}
                                                          
                                                          public  		string
              customerCounty
 {get; set;}
                                                          
                                                          public  		string
              customerVillage
 {get; set;}
                                                          
                                                          public  		string
              customerDetailAddress
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  wareName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  warePrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  wareNum {get; set; }
                                                                                                                                                                                                public  		string
              extJsonStr
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.asc.audit.compensate";}
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
                                                                                                        parameters.Add("deliveryCenterId", this.            deliveryCenterId
);
                                                                                                        parameters.Add("deliveryCenterName", this.            deliveryCenterName
);
                                                                                                        parameters.Add("storeId", this.            storeId
);
                                                                                                                                                parameters.Add("customerContactName", this.            customerContactName
);
                                                                                                        parameters.Add("customerContactTel", this.            customerContactTel
);
                                                                                                        parameters.Add("customerContactMobile", this.            customerContactMobile
);
                                                                                                        parameters.Add("customerZipcode", this.            customerZipcode
);
                                                                                                        parameters.Add("customerProvince", this.            customerProvince
);
                                                                                                        parameters.Add("customerCity", this.            customerCity
);
                                                                                                        parameters.Add("customerCounty", this.            customerCounty
);
                                                                                                        parameters.Add("customerVillage", this.            customerVillage
);
                                                                                                        parameters.Add("customerDetailAddress", this.            customerDetailAddress
);
                                                                                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("wareName", this.            wareName
);
                                                                                                        parameters.Add("warePrice", this.            warePrice
);
                                                                                                        parameters.Add("wareNum", this.            wareNum
);
                                                                                                                                                        parameters.Add("extJsonStr", this.            extJsonStr
);
                                                                            }
    }
}





        
 

