using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LdopDeliveryDeliveryPickupReceiveRequest : JdRequestBase<LdopDeliveryDeliveryPickupReceiveResponse>
    {
                                                                                                                                              public  		string
              josPin
 {get; set;}
                                                          
                                                                                           public  		string
              salePlat
 {get; set;}
                                                          
                                                          public  		string
              customerCode
 {get; set;}
                                                          
                                                          public  		string
              orderId
 {get; set;}
                                                          
                                                          public  		string
              thrOrderId
 {get; set;}
                                                          
                                                          public  		string
              senderName
 {get; set;}
                                                          
                                                          public  		string
              senderAddress
 {get; set;}
                                                          
                                                          public  		string
              senderTel
 {get; set;}
                                                          
                                                          public  		string
              senderMobile
 {get; set;}
                                                          
                                                          public  		string
              receiveName
 {get; set;}
                                                          
                                                          public  		string
              receiveAddress
 {get; set;}
                                                          
                                                          public  		string
              receiveTel
 {get; set;}
                                                          
                                                          public  		string
              receiveMobile
 {get; set;}
                                                          
                                                          public  		string
              province
 {get; set;}
                                                          
                                                          public  		string
              city
 {get; set;}
                                                          
                                                          public  		string
              county
 {get; set;}
                                                          
                                                          public  		string
              town
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packageCount
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              weight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              vloumLong
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              vloumWidth
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              vloumHeight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              vloumn
 {get; set;}
                                                          
                                                          public  		string
              description
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              goodsMoney
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              collectionValue
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              collectionMoney
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              guaranteeValue
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              guaranteeValueAmount
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              signReturn
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              aging
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              goodsType
 {get; set;}
                                                          
                                                          public  		string
              warehouseCode
 {get; set;}
                                                          
                                                          public  		string
              remark
 {get; set;}
                                                          
                                                          public  		string
              idNumber
 {get; set;}
                                                          
                                                          public  		string
              addedService
 {get; set;}
                                                          
                                                          public  		string
              senderCompany
 {get; set;}
                                                          
                                                          public  		string
              receiveCompany
 {get; set;}
                                                          
                                                          public  		string
              senderIdNumber
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              senderIdType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              sendAndPickupType
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      openIdSeller
 {get; set;}
                                                                                                                                                          
                                                                                                                                                       public  		string
              customerTel
 {get; set;}
                                                          
                                                          public  		string
              backAddress
 {get; set;}
                                                          
                                                          public  		string
              customerContract
 {get; set;}
                                                          
                                                          public  		string
              pickupOrderId
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              pickupWeight
 {get; set;}
                                                          
                                                          public  		string
              pickupRemark
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              pickupVolume
 {get; set;}
                                                          
                                                          public  		string
              isGuaranteeValue
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              pickupGuaranteeValueAmount
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pickupGoodsType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pickupBizType
 {get; set;}
                                                          
                                                          public  		string
              valueAddService
 {get; set;}
                                                          
                                                          public  		string
              pickupSenderIdNumber
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pickupSenderIdType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  productId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  snCode {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productCount {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuAddService {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuCheckOutShapes {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuCheckAttachFile {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              promiseTimeType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              guaranteeSettleType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packingSettleType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              freightSettleType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.ldop.delivery.deliveryPickupReceive";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("josPin", this.            josPin
);
                                                                                                                                                        parameters.Add("salePlat", this.            salePlat
);
                                                                                                        parameters.Add("customerCode", this.            customerCode
);
                                                                                                        parameters.Add("orderId", this.            orderId
);
                                                                                                        parameters.Add("thrOrderId", this.            thrOrderId
);
                                                                                                        parameters.Add("senderName", this.            senderName
);
                                                                                                        parameters.Add("senderAddress", this.            senderAddress
);
                                                                                                        parameters.Add("senderTel", this.            senderTel
);
                                                                                                        parameters.Add("senderMobile", this.            senderMobile
);
                                                                                                        parameters.Add("receiveName", this.            receiveName
);
                                                                                                        parameters.Add("receiveAddress", this.            receiveAddress
);
                                                                                                        parameters.Add("receiveTel", this.            receiveTel
);
                                                                                                        parameters.Add("receiveMobile", this.            receiveMobile
);
                                                                                                        parameters.Add("province", this.            province
);
                                                                                                        parameters.Add("city", this.            city
);
                                                                                                        parameters.Add("county", this.            county
);
                                                                                                        parameters.Add("town", this.            town
);
                                                                                                        parameters.Add("packageCount", this.            packageCount
);
                                                                                                        parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("vloumLong", this.            vloumLong
);
                                                                                                        parameters.Add("vloumWidth", this.            vloumWidth
);
                                                                                                        parameters.Add("vloumHeight", this.            vloumHeight
);
                                                                                                        parameters.Add("vloumn", this.            vloumn
);
                                                                                                        parameters.Add("description", this.            description
);
                                                                                                        parameters.Add("goodsMoney", this.            goodsMoney
);
                                                                                                        parameters.Add("collectionValue", this.            collectionValue
);
                                                                                                        parameters.Add("collectionMoney", this.            collectionMoney
);
                                                                                                        parameters.Add("guaranteeValue", this.            guaranteeValue
);
                                                                                                        parameters.Add("guaranteeValueAmount", this.            guaranteeValueAmount
);
                                                                                                        parameters.Add("signReturn", this.            signReturn
);
                                                                                                        parameters.Add("aging", this.            aging
);
                                                                                                        parameters.Add("goodsType", this.            goodsType
);
                                                                                                        parameters.Add("warehouseCode", this.            warehouseCode
);
                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("idNumber", this.            idNumber
);
                                                                                                        parameters.Add("addedService", this.            addedService
);
                                                                                                        parameters.Add("senderCompany", this.            senderCompany
);
                                                                                                        parameters.Add("receiveCompany", this.            receiveCompany
);
                                                                                                        parameters.Add("senderIdNumber", this.            senderIdNumber
);
                                                                                                        parameters.Add("senderIdType", this.            senderIdType
);
                                                                                                        parameters.Add("sendAndPickupType", this.            sendAndPickupType
);
                                                                                                        parameters.Add("open_id_seller", this.                                                                                                                    openIdSeller
);
                                                                                                                                                                        parameters.Add("customerTel", this.            customerTel
);
                                                                                                        parameters.Add("backAddress", this.            backAddress
);
                                                                                                        parameters.Add("customerContract", this.            customerContract
);
                                                                                                        parameters.Add("pickupOrderId", this.            pickupOrderId
);
                                                                                                        parameters.Add("pickupWeight", this.            pickupWeight
);
                                                                                                        parameters.Add("pickupRemark", this.            pickupRemark
);
                                                                                                        parameters.Add("pickupVolume", this.            pickupVolume
);
                                                                                                        parameters.Add("isGuaranteeValue", this.            isGuaranteeValue
);
                                                                                                        parameters.Add("pickupGuaranteeValueAmount", this.            pickupGuaranteeValueAmount
);
                                                                                                        parameters.Add("pickupGoodsType", this.            pickupGoodsType
);
                                                                                                        parameters.Add("pickupBizType", this.            pickupBizType
);
                                                                                                        parameters.Add("valueAddService", this.            valueAddService
);
                                                                                                        parameters.Add("pickupSenderIdNumber", this.            pickupSenderIdNumber
);
                                                                                                        parameters.Add("pickupSenderIdType", this.            pickupSenderIdType
);
                                                                                                                                                                                        parameters.Add("productId", this.            productId
);
                                                                                                        parameters.Add("snCode", this.            snCode
);
                                                                                                        parameters.Add("productName", this.            productName
);
                                                                                                        parameters.Add("productCount", this.            productCount
);
                                                                                                        parameters.Add("skuAddService", this.            skuAddService
);
                                                                                                        parameters.Add("skuCheckOutShapes", this.            skuCheckOutShapes
);
                                                                                                        parameters.Add("skuCheckAttachFile", this.            skuCheckAttachFile
);
                                                                                                                                                        parameters.Add("promiseTimeType", this.            promiseTimeType
);
                                                                                                        parameters.Add("guaranteeSettleType", this.            guaranteeSettleType
);
                                                                                                        parameters.Add("packingSettleType", this.            packingSettleType
);
                                                                                                        parameters.Add("freightSettleType", this.            freightSettleType
);
                                                                            }
    }
}





        
 

