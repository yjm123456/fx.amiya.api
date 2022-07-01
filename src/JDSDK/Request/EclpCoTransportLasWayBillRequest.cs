using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpCoTransportLasWayBillRequest : JdRequestBase<EclpCoTransportLasWayBillResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              orderNo
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
              remark
 {get; set;}
                                                          
                                                          public  		string
              isFragile
 {get; set;}
                                                          
                                                          public  		string
              senderTc
 {get; set;}
                                                          
                                                          public  		string
              predictDate
 {get; set;}
                                                          
                                                          public  		string
              isJDOrder
 {get; set;}
                                                          
                                                          public  		string
              isCod
 {get; set;}
                                                          
                                                          public  		string
              receiveable
 {get; set;}
                                                          
                                                          public  		string
              onDoorPickUp
 {get; set;}
                                                          
                                                          public  		string
              pickUpDate
 {get; set;}
                                                          
                                                          public  		string
              isGuarantee
 {get; set;}
                                                          
                                                          public  		string
              guaranteeValue
 {get; set;}
                                                          
                                                          public  		string
              receiptFlag
 {get; set;}
                                                          
                                                          public  		string
              paperFrom
 {get; set;}
                                                          
                                                          public  		string
              rtnReceiverName
 {get; set;}
                                                          
                                                          public  		string
              rtnReceiverMobile
 {get; set;}
                                                          
                                                          public  		string
              rtnReceiverAddress
 {get; set;}
                                                          
                                                          public  		string
              rtnReceiverPhone
 {get; set;}
                                                          
                                                          public  		string
              productType
 {get; set;}
                                                          
                                                          public  		string
              pickUpForNew
 {get; set;}
                                                          
                                                          public  		string
              pickUpAbnormalNumber
 {get; set;}
                                                          
                                                          public  		string
              pickUpReceiverName
 {get; set;}
                                                          
                                                          public  		string
              pickUpReceiverMobile
 {get; set;}
                                                          
                                                          public  		string
              pickUpReceiverPhone
 {get; set;}
                                                          
                                                          public  		string
              pickUpReceiverCode
 {get; set;}
                                                          
                                                          public  		string
              pickUpReceiverAddress
 {get; set;}
                                                          
                                                          public  		string
              isSignPrint
 {get; set;}
                                                          
                                                          public  		string
              sameCityDelivery
 {get; set;}
                                                          
                                                          public  		string
              lasDischarge
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              thirdPayment
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
  installFlag {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  thirdCategoryNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  brandNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productSku {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  packageName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  reverseLwb {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  getOldService {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  openBoxService {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  deliveryInstallService {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  packageIdentityCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  price {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lasInstall {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.co.transportLasWayBill";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
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
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("isFragile", this.            isFragile
);
                                                                                                        parameters.Add("senderTc", this.            senderTc
);
                                                                                                        parameters.Add("predictDate", this.            predictDate
);
                                                                                                        parameters.Add("isJDOrder", this.            isJDOrder
);
                                                                                                        parameters.Add("isCod", this.            isCod
);
                                                                                                        parameters.Add("receiveable", this.            receiveable
);
                                                                                                        parameters.Add("onDoorPickUp", this.            onDoorPickUp
);
                                                                                                        parameters.Add("pickUpDate", this.            pickUpDate
);
                                                                                                        parameters.Add("isGuarantee", this.            isGuarantee
);
                                                                                                        parameters.Add("guaranteeValue", this.            guaranteeValue
);
                                                                                                        parameters.Add("receiptFlag", this.            receiptFlag
);
                                                                                                        parameters.Add("paperFrom", this.            paperFrom
);
                                                                                                        parameters.Add("rtnReceiverName", this.            rtnReceiverName
);
                                                                                                        parameters.Add("rtnReceiverMobile", this.            rtnReceiverMobile
);
                                                                                                        parameters.Add("rtnReceiverAddress", this.            rtnReceiverAddress
);
                                                                                                        parameters.Add("rtnReceiverPhone", this.            rtnReceiverPhone
);
                                                                                                        parameters.Add("productType", this.            productType
);
                                                                                                        parameters.Add("pickUpForNew", this.            pickUpForNew
);
                                                                                                        parameters.Add("pickUpAbnormalNumber", this.            pickUpAbnormalNumber
);
                                                                                                        parameters.Add("pickUpReceiverName", this.            pickUpReceiverName
);
                                                                                                        parameters.Add("pickUpReceiverMobile", this.            pickUpReceiverMobile
);
                                                                                                        parameters.Add("pickUpReceiverPhone", this.            pickUpReceiverPhone
);
                                                                                                        parameters.Add("pickUpReceiverCode", this.            pickUpReceiverCode
);
                                                                                                        parameters.Add("pickUpReceiverAddress", this.            pickUpReceiverAddress
);
                                                                                                        parameters.Add("isSignPrint", this.            isSignPrint
);
                                                                                                        parameters.Add("sameCityDelivery", this.            sameCityDelivery
);
                                                                                                        parameters.Add("lasDischarge", this.            lasDischarge
);
                                                                                                        parameters.Add("thirdPayment", this.            thirdPayment
);
                                                                                                                                                                                                                parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("length", this.            length
);
                                                                                                        parameters.Add("width", this.            width
);
                                                                                                        parameters.Add("height", this.            height
);
                                                                                                        parameters.Add("installFlag", this.            installFlag
);
                                                                                                        parameters.Add("thirdCategoryNo", this.            thirdCategoryNo
);
                                                                                                        parameters.Add("brandNo", this.            brandNo
);
                                                                                                        parameters.Add("productSku", this.            productSku
);
                                                                                                        parameters.Add("packageName", this.            packageName
);
                                                                                                        parameters.Add("reverseLwb", this.            reverseLwb
);
                                                                                                        parameters.Add("getOldService", this.            getOldService
);
                                                                                                        parameters.Add("openBoxService", this.            openBoxService
);
                                                                                                        parameters.Add("deliveryInstallService", this.            deliveryInstallService
);
                                                                                                        parameters.Add("packageIdentityCode", this.            packageIdentityCode
);
                                                                                                        parameters.Add("price", this.            price
);
                                                                                                        parameters.Add("lasInstall", this.            lasInstall
);
                                                                                                                                                    }
    }
}





        
 

