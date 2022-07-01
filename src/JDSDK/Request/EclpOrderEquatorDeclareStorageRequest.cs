using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpOrderEquatorDeclareStorageRequest : JdRequestBase<EclpOrderEquatorDeclareStorageResponse>
    {
                                                                                                                                              public  		string
              isvUUID
 {get; set;}
                                                          
                                                          public  		string
              isvSource
 {get; set;}
                                                          
                                                          public  		string
              platformId
 {get; set;}
                                                          
                                                          public  		string
              platformName
 {get; set;}
                                                          
                                                          public  		string
              platformType
 {get; set;}
                                                          
                                                          public  		string
              spSoNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              inJdwms
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              salesPlatformCreateTime
 {get; set;}
                                                          
                                                          public  		string
              venderId
 {get; set;}
                                                          
                                                          public  		string
              venderName
 {get; set;}
                                                          
                                                          public  		string
              consigneeName
 {get; set;}
                                                          
                                                          public  		string
              consigneeMobile
 {get; set;}
                                                          
                                                          public  		string
              consigneePhone
 {get; set;}
                                                          
                                                          public  		string
              consigneeEmail
 {get; set;}
                                                          
                                                          public  		string
              consigneeAddress
 {get; set;}
                                                          
                                                          public  		string
              consigneePostcode
 {get; set;}
                                                          
                                                          public  		string
              consigneeCountry
 {get; set;}
                                                          
                                                          public  		string
              addressProvince
 {get; set;}
                                                          
                                                          public  		string
              addressCity
 {get; set;}
                                                          
                                                          public  		string
              addressCounty
 {get; set;}
                                                          
                                                          public  		string
              addressTown
 {get; set;}
                                                          
                                                          public  		string
              soType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              expectDate
 {get; set;}
                                                          
                                                          public  		string
              invoiceTitle
 {get; set;}
                                                          
                                                          public  		string
              invoiceContent
 {get; set;}
                                                          
                                                          public  		string
              declareOrder
 {get; set;}
                                                          
                                                          public  		string
              ccProvider
 {get; set;}
                                                          
                                                          public  		string
              ccProviderName
 {get; set;}
                                                          
                                                          public  		string
              postType
 {get; set;}
                                                          
                                                          public  		string
              pattern
 {get; set;}
                                                          
                                                          public  		string
              customs
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              ebpCode
 {get; set;}
                                                          
                                                          public  		string
              ebpName
 {get; set;}
                                                          
                                                          public  		string
              ebcCode
 {get; set;}
                                                          
                                                          public  		string
              ebcName
 {get; set;}
                                                          
                                                          public  		string
              delivery
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              discount
 {get; set;}
                                                          
                                                          public  		string
              discountNote
 {get; set;}
                                                          
                                                          public  		string
              istax
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              taxTotal
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              freight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              otherPrice
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              goodsValue
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              weight
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              netWeight
 {get; set;}
                                                          
                                                          public  		string
              batchNumbers
 {get; set;}
                                                          
                                                          public  		string
              buyerRegNo
 {get; set;}
                                                          
                                                          public  		string
              buyerPhone
 {get; set;}
                                                          
                                                          public  		string
              buyerName
 {get; set;}
                                                          
                                                          public  		string
              buyerIdType
 {get; set;}
                                                          
                                                          public  		string
              buyerIdNumber
 {get; set;}
                                                          
                                                          public  		string
              senderName
 {get; set;}
                                                          
                                                          public  		string
              senderCompanyName
 {get; set;}
                                                          
                                                          public  		string
              senderCountry
 {get; set;}
                                                          
                                                          public  		string
              senderZip
 {get; set;}
                                                          
                                                          public  		string
              senderCity
 {get; set;}
                                                          
                                                          public  		string
              senderProvince
 {get; set;}
                                                          
                                                          public  		string
              senderTel
 {get; set;}
                                                          
                                                          public  		string
              senderAddr
 {get; set;}
                                                          
                                                          public  		string
              customsRemark
 {get; set;}
                                                          
                                                          public  		string
              declarePaymentList
 {get; set;}
                                                          
                                                          public  		string
              paymentType
 {get; set;}
                                                          
                                                          public  		string
              payCode
 {get; set;}
                                                          
                                                          public  		string
              payName
 {get; set;}
                                                          
                                                          public  		string
              payTransactionId
 {get; set;}
                                                          
                                                          public  		string
              currency
 {get; set;}
                                                          
                                                          public  		string
              paymentConfirmTime
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              shouldPay
 {get; set;}
                                                          
                                                          public  		string
              receiveNo
 {get; set;}
                                                          
                                                          public  		string
              payRemark
 {get; set;}
                                                          
                                                          public  		string
              declareWaybill
 {get; set;}
                                                          
                                                          public  		string
              logisticsCode
 {get; set;}
                                                          
                                                          public  		string
              logisticsName
 {get; set;}
                                                          
                                                          public  		string
              bdOwnerNo
 {get; set;}
                                                          
                                                          public  		string
              logisticsNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              packNo
 {get; set;}
                                                          
                                                          public  		string
              logisticsRemark
 {get; set;}
                                                          
                                                          public  		string
              isDelivery
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              receivable
 {get; set;}
                                                          
                                                          public  		string
              consigneeRemark
 {get; set;}
                                                          
                                                          public  		string
              packageMark
 {get; set;}
                                                          
                                                          public  		string
              businessType
 {get; set;}
                                                          
                                                          public  		string
              destinationCode
 {get; set;}
                                                          
                                                          public  		string
              destinationName
 {get; set;}
                                                          
                                                          public  		string
              sendWebsiteCode
 {get; set;}
                                                          
                                                          public  		string
              sendWebsiteName
 {get; set;}
                                                          
                                                          public  		string
              sendMode
 {get; set;}
                                                          
                                                          public  		string
              receiveMode
 {get; set;}
                                                          
                                                          public  		string
              appointDeliveryTime
 {get; set;}
                                                          
                                                          public  		string
              insuredPriceFlag
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              insuredValue
 {get; set;}
                                                          
                                                          public  	    Nullable<double>
              insuredFee
 {get; set;}
                                                          
                                                          public  		string
              thirdPayment
 {get; set;}
                                                          
                                                          public  		string
              monthlyAccount
 {get; set;}
                                                          
                                                          public  		string
              shipment
 {get; set;}
                                                          
                                                          public  		string
              sellerRemark
 {get; set;}
                                                          
                                                          public  		string
              thirdSite
 {get; set;}
                                                          
                                                          public  		string
              shopNo
 {get; set;}
                                                          
                                                          public  		string
              isSupervise
 {get; set;}
                                                          
                                                          public  		string
              initalRequest
 {get; set;}
                                                          
                                                          public  		string
              initalResponse
 {get; set;}
                                                          
                                                          public  		string
              payTransactionIdYh
 {get; set;}
                                                          
                                                          public  		string
              isvParentId
 {get; set;}
                                                          
                                                          public  		string
              isvOrderIdList
 {get; set;}
                                                          
                                                          public  		string
              totalAmount
 {get; set;}
                                                          
                                                          public  		string
              verDept
 {get; set;}
                                                          
                                                          public  		string
              payType
 {get; set;}
                                                          
                                                          public  		string
              recpAccount
 {get; set;}
                                                          
                                                          public  		string
              recpCode
 {get; set;}
                                                          
                                                          public  		string
              recpName
 {get; set;}
                                                          
                                                          public  		string
              consNameEN
 {get; set;}
                                                          
                                                          public  		string
              consAddressEN
 {get; set;}
                                                          
                                                          public  		string
              senderNameEN
 {get; set;}
                                                          
                                                          public  		string
              senderCityEN
 {get; set;}
                                                          
                                                          public  		string
              senderAddrEN
 {get; set;}
                                                          
                                                          public  		string
              wrapType
 {get; set;}
                                                          
                                                          public  		string
              consigneeIdType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                             		public  		string
  gnum {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  isvGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  spGoodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  quantity {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  price {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  goodsRemark {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  itemLink {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  productionDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  expirationDate {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  packBatchNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  poNo {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  lot {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.eclp.order.equatorDeclareStorage";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("isvUUID", this.            isvUUID
);
                                                                                                        parameters.Add("isvSource", this.            isvSource
);
                                                                                                        parameters.Add("platformId", this.            platformId
);
                                                                                                        parameters.Add("platformName", this.            platformName
);
                                                                                                        parameters.Add("platformType", this.            platformType
);
                                                                                                        parameters.Add("spSoNo", this.            spSoNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("inJdwms", this.            inJdwms
);
                                                                                                        parameters.Add("salesPlatformCreateTime", this.            salesPlatformCreateTime
);
                                                                                                        parameters.Add("venderId", this.            venderId
);
                                                                                                        parameters.Add("venderName", this.            venderName
);
                                                                                                        parameters.Add("consigneeName", this.            consigneeName
);
                                                                                                        parameters.Add("consigneeMobile", this.            consigneeMobile
);
                                                                                                        parameters.Add("consigneePhone", this.            consigneePhone
);
                                                                                                        parameters.Add("consigneeEmail", this.            consigneeEmail
);
                                                                                                        parameters.Add("consigneeAddress", this.            consigneeAddress
);
                                                                                                        parameters.Add("consigneePostcode", this.            consigneePostcode
);
                                                                                                        parameters.Add("consigneeCountry", this.            consigneeCountry
);
                                                                                                        parameters.Add("addressProvince", this.            addressProvince
);
                                                                                                        parameters.Add("addressCity", this.            addressCity
);
                                                                                                        parameters.Add("addressCounty", this.            addressCounty
);
                                                                                                        parameters.Add("addressTown", this.            addressTown
);
                                                                                                        parameters.Add("soType", this.            soType
);
                                                                                                        parameters.Add("expectDate", this.            expectDate
);
                                                                                                        parameters.Add("invoiceTitle", this.            invoiceTitle
);
                                                                                                        parameters.Add("invoiceContent", this.            invoiceContent
);
                                                                                                        parameters.Add("declareOrder", this.            declareOrder
);
                                                                                                        parameters.Add("ccProvider", this.            ccProvider
);
                                                                                                        parameters.Add("ccProviderName", this.            ccProviderName
);
                                                                                                        parameters.Add("postType", this.            postType
);
                                                                                                        parameters.Add("pattern", this.            pattern
);
                                                                                                        parameters.Add("customs", this.            customs
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("ebpCode", this.            ebpCode
);
                                                                                                        parameters.Add("ebpName", this.            ebpName
);
                                                                                                        parameters.Add("ebcCode", this.            ebcCode
);
                                                                                                        parameters.Add("ebcName", this.            ebcName
);
                                                                                                        parameters.Add("delivery", this.            delivery
);
                                                                                                        parameters.Add("discount", this.            discount
);
                                                                                                        parameters.Add("discountNote", this.            discountNote
);
                                                                                                        parameters.Add("istax", this.            istax
);
                                                                                                        parameters.Add("taxTotal", this.            taxTotal
);
                                                                                                        parameters.Add("freight", this.            freight
);
                                                                                                        parameters.Add("otherPrice", this.            otherPrice
);
                                                                                                        parameters.Add("goodsValue", this.            goodsValue
);
                                                                                                        parameters.Add("weight", this.            weight
);
                                                                                                        parameters.Add("netWeight", this.            netWeight
);
                                                                                                        parameters.Add("batchNumbers", this.            batchNumbers
);
                                                                                                        parameters.Add("buyerRegNo", this.            buyerRegNo
);
                                                                                                        parameters.Add("buyerPhone", this.            buyerPhone
);
                                                                                                        parameters.Add("buyerName", this.            buyerName
);
                                                                                                        parameters.Add("buyerIdType", this.            buyerIdType
);
                                                                                                        parameters.Add("buyerIdNumber", this.            buyerIdNumber
);
                                                                                                        parameters.Add("senderName", this.            senderName
);
                                                                                                        parameters.Add("senderCompanyName", this.            senderCompanyName
);
                                                                                                        parameters.Add("senderCountry", this.            senderCountry
);
                                                                                                        parameters.Add("senderZip", this.            senderZip
);
                                                                                                        parameters.Add("senderCity", this.            senderCity
);
                                                                                                        parameters.Add("senderProvince", this.            senderProvince
);
                                                                                                        parameters.Add("senderTel", this.            senderTel
);
                                                                                                        parameters.Add("senderAddr", this.            senderAddr
);
                                                                                                        parameters.Add("customsRemark", this.            customsRemark
);
                                                                                                        parameters.Add("declarePaymentList", this.            declarePaymentList
);
                                                                                                        parameters.Add("paymentType", this.            paymentType
);
                                                                                                        parameters.Add("payCode", this.            payCode
);
                                                                                                        parameters.Add("payName", this.            payName
);
                                                                                                        parameters.Add("payTransactionId", this.            payTransactionId
);
                                                                                                        parameters.Add("currency", this.            currency
);
                                                                                                        parameters.Add("paymentConfirmTime", this.            paymentConfirmTime
);
                                                                                                        parameters.Add("shouldPay", this.            shouldPay
);
                                                                                                        parameters.Add("receiveNo", this.            receiveNo
);
                                                                                                        parameters.Add("payRemark", this.            payRemark
);
                                                                                                        parameters.Add("declareWaybill", this.            declareWaybill
);
                                                                                                        parameters.Add("logisticsCode", this.            logisticsCode
);
                                                                                                        parameters.Add("logisticsName", this.            logisticsName
);
                                                                                                        parameters.Add("bdOwnerNo", this.            bdOwnerNo
);
                                                                                                        parameters.Add("logisticsNo", this.            logisticsNo
);
                                                                                                        parameters.Add("packNo", this.            packNo
);
                                                                                                        parameters.Add("logisticsRemark", this.            logisticsRemark
);
                                                                                                        parameters.Add("isDelivery", this.            isDelivery
);
                                                                                                        parameters.Add("receivable", this.            receivable
);
                                                                                                        parameters.Add("consigneeRemark", this.            consigneeRemark
);
                                                                                                        parameters.Add("packageMark", this.            packageMark
);
                                                                                                        parameters.Add("businessType", this.            businessType
);
                                                                                                        parameters.Add("destinationCode", this.            destinationCode
);
                                                                                                        parameters.Add("destinationName", this.            destinationName
);
                                                                                                        parameters.Add("sendWebsiteCode", this.            sendWebsiteCode
);
                                                                                                        parameters.Add("sendWebsiteName", this.            sendWebsiteName
);
                                                                                                        parameters.Add("sendMode", this.            sendMode
);
                                                                                                        parameters.Add("receiveMode", this.            receiveMode
);
                                                                                                        parameters.Add("appointDeliveryTime", this.            appointDeliveryTime
);
                                                                                                        parameters.Add("insuredPriceFlag", this.            insuredPriceFlag
);
                                                                                                        parameters.Add("insuredValue", this.            insuredValue
);
                                                                                                        parameters.Add("insuredFee", this.            insuredFee
);
                                                                                                        parameters.Add("thirdPayment", this.            thirdPayment
);
                                                                                                        parameters.Add("monthlyAccount", this.            monthlyAccount
);
                                                                                                        parameters.Add("shipment", this.            shipment
);
                                                                                                        parameters.Add("sellerRemark", this.            sellerRemark
);
                                                                                                        parameters.Add("thirdSite", this.            thirdSite
);
                                                                                                        parameters.Add("shopNo", this.            shopNo
);
                                                                                                        parameters.Add("isSupervise", this.            isSupervise
);
                                                                                                        parameters.Add("initalRequest", this.            initalRequest
);
                                                                                                        parameters.Add("initalResponse", this.            initalResponse
);
                                                                                                        parameters.Add("payTransactionIdYh", this.            payTransactionIdYh
);
                                                                                                        parameters.Add("isvParentId", this.            isvParentId
);
                                                                                                        parameters.Add("isvOrderIdList", this.            isvOrderIdList
);
                                                                                                        parameters.Add("totalAmount", this.            totalAmount
);
                                                                                                        parameters.Add("verDept", this.            verDept
);
                                                                                                        parameters.Add("payType", this.            payType
);
                                                                                                        parameters.Add("recpAccount", this.            recpAccount
);
                                                                                                        parameters.Add("recpCode", this.            recpCode
);
                                                                                                        parameters.Add("recpName", this.            recpName
);
                                                                                                        parameters.Add("consNameEN", this.            consNameEN
);
                                                                                                        parameters.Add("consAddressEN", this.            consAddressEN
);
                                                                                                        parameters.Add("senderNameEN", this.            senderNameEN
);
                                                                                                        parameters.Add("senderCityEN", this.            senderCityEN
);
                                                                                                        parameters.Add("senderAddrEN", this.            senderAddrEN
);
                                                                                                        parameters.Add("wrapType", this.            wrapType
);
                                                                                                        parameters.Add("consigneeIdType", this.            consigneeIdType
);
                                                                                                                                                                                                                parameters.Add("gnum", this.            gnum
);
                                                                                                        parameters.Add("isvGoodsNo", this.            isvGoodsNo
);
                                                                                                        parameters.Add("spGoodsNo", this.            spGoodsNo
);
                                                                                                        parameters.Add("quantity", this.            quantity
);
                                                                                                        parameters.Add("price", this.            price
);
                                                                                                        parameters.Add("goodsRemark", this.            goodsRemark
);
                                                                                                        parameters.Add("itemLink", this.            itemLink
);
                                                                                                        parameters.Add("productionDate", this.            productionDate
);
                                                                                                        parameters.Add("expirationDate", this.            expirationDate
);
                                                                                                        parameters.Add("packBatchNo", this.            packBatchNo
);
                                                                                                        parameters.Add("poNo", this.            poNo
);
                                                                                                        parameters.Add("lot", this.            lot
);
                                                                                                                                                    }
    }
}





        
 

