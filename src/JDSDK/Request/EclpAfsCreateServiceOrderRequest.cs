using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpAfsCreateServiceOrderRequest : JdRequestBase<EclpAfsCreateServiceOrderResponse>
    {
                                                                                                                                              public  		string
              isvUUId
 {get; set;}
                                                          
                                                          public  		string
              isvSource
 {get; set;}
                                                          
                                                          public  		string
              shopNo
 {get; set;}
                                                          
                                                          public  		string
              departmentNo
 {get; set;}
                                                          
                                                          public  		string
              shipperNo
 {get; set;}
                                                          
                                                          public  		string
              eclpOrderId
 {get; set;}
                                                          
                                                          public  		string
              salePlatformSource
 {get; set;}
                                                          
                                                          public  		string
              salesPlatformCreateTime
 {get; set;}
                                                          
                                                          public  		string
              sourceType
 {get; set;}
                                                          
                                                          public  		string
              pickupType
 {get; set;}
                                                          
                                                          public  		string
              isInvoice
 {get; set;}
                                                          
                                                          public  		string
              invoiceNo
 {get; set;}
                                                          
                                                          public  		string
              isPackage
 {get; set;}
                                                          
                                                          public  		string
              isTestReport
 {get; set;}
                                                          
                                                          public  		string
              customerName
 {get; set;}
                                                          
                                                          public  		string
              customerTel
 {get; set;}
                                                          
                                                          public  		string
              provinceNo
 {get; set;}
                                                          
                                                          public  		string
              provinceName
 {get; set;}
                                                          
                                                          public  		string
              cityName
 {get; set;}
                                                          
                                                          public  		string
              cityNo
 {get; set;}
                                                          
                                                          public  		string
              countyName
 {get; set;}
                                                          
                                                          public  		string
              countyNo
 {get; set;}
                                                          
                                                          public  		string
              townName
 {get; set;}
                                                          
                                                          public  		string
              townNo
 {get; set;}
                                                          
                                                          public  		string
              customerAddress
 {get; set;}
                                                          
                                                          public  		string
              pickupAddress
 {get; set;}
                                                          
                                                          public  		string
              operatorId
 {get; set;}
                                                          
                                                          public  		string
              operatorName
 {get; set;}
                                                          
                                                          public  		string
              operateTime
 {get; set;}
                                                          
                                                          public  		string
              pickupNo
 {get; set;}
                                                          
                                                          public  		string
              questionDesc
 {get; set;}
                                                          
                                                          public  		string
              applyReason
 {get; set;}
                                                          
                                                          public  		string
              amsAuditComment
 {get; set;}
                                                          
                                                          public  		string
              waybill
 {get; set;}
                                                          
                                                          public  		string
              pickwaretype
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  isvGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quantity {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  weight {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sn {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  attachmentDetails {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  wareType {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              isCreatePickup
 {get; set;}
                                                          
                                                          public  		string
              businessPhone
 {get; set;}
                                                          
                                                          public  		string
              outPickupType
 {get; set;}
                                                          
                                                          public  		string
              afterSalesChangeNo
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.afs.createServiceOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("isvUUId", this.            isvUUId
);
                                                                                                        parameters.Add("isvSource", this.            isvSource
);
                                                                                                        parameters.Add("shopNo", this.            shopNo
);
                                                                                                        parameters.Add("departmentNo", this.            departmentNo
);
                                                                                                        parameters.Add("shipperNo", this.            shipperNo
);
                                                                                                        parameters.Add("eclpOrderId", this.            eclpOrderId
);
                                                                                                        parameters.Add("salePlatformSource", this.            salePlatformSource
);
                                                                                                        parameters.Add("salesPlatformCreateTime", this.            salesPlatformCreateTime
);
                                                                                                        parameters.Add("sourceType", this.            sourceType
);
                                                                                                        parameters.Add("pickupType", this.            pickupType
);
                                                                                                        parameters.Add("isInvoice", this.            isInvoice
);
                                                                                                        parameters.Add("invoiceNo", this.            invoiceNo
);
                                                                                                        parameters.Add("isPackage", this.            isPackage
);
                                                                                                        parameters.Add("isTestReport", this.            isTestReport
);
                                                                                                        parameters.Add("customerName", this.            customerName
);
                                                                                                        parameters.Add("customerTel", this.            customerTel
);
                                                                                                        parameters.Add("provinceNo", this.            provinceNo
);
                                                                                                        parameters.Add("provinceName", this.            provinceName
);
                                                                                                        parameters.Add("cityName", this.            cityName
);
                                                                                                        parameters.Add("cityNo", this.            cityNo
);
                                                                                                        parameters.Add("countyName", this.            countyName
);
                                                                                                        parameters.Add("countyNo", this.            countyNo
);
                                                                                                        parameters.Add("townName", this.            townName
);
                                                                                                        parameters.Add("townNo", this.            townNo
);
                                                                                                        parameters.Add("customerAddress", this.            customerAddress
);
                                                                                                        parameters.Add("pickupAddress", this.            pickupAddress
);
                                                                                                        parameters.Add("operatorId", this.            operatorId
);
                                                                                                        parameters.Add("operatorName", this.            operatorName
);
                                                                                                        parameters.Add("operateTime", this.            operateTime
);
                                                                                                        parameters.Add("pickupNo", this.            pickupNo
);
                                                                                                        parameters.Add("questionDesc", this.            questionDesc
);
                                                                                                        parameters.Add("applyReason", this.            applyReason
);
                                                                                                        parameters.Add("amsAuditComment", this.            amsAuditComment
);
                                                                                                        parameters.Add("waybill", this.            waybill
);
                                                                                                        parameters.Add("pickwaretype", this.            pickwaretype
);
                                                                                                                                                                                        parameters.Add("isvGoodsNo", this.            isvGoodsNo
);
                                                                                                        parameters.Add("quantity", this.            quantity
);
                                                                                                        parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("sn", this.            sn
);
                                                                                                        parameters.Add("attachmentDetails", this.            attachmentDetails
);
                                                                                                        parameters.Add("wareType", this.            wareType
);
                                                                                                                                                        parameters.Add("isCreatePickup", this.            isCreatePickup
);
                                                                                                        parameters.Add("businessPhone", this.            businessPhone
);
                                                                                                        parameters.Add("outPickupType", this.            outPickupType
);
                                                                                                        parameters.Add("afterSalesChangeNo", this.            afterSalesChangeNo
);
                                                                                                                            }
    }
}





        
 

