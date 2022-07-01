using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderInfoFBP:JdObject{
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("venderId")]
public 				string

             venderId
 { get; set; }
      [JsonProperty("orderType")]
public 				string

             orderType
 { get; set; }
      [JsonProperty("payType")]
public 				string

             payType
 { get; set; }
      [JsonProperty("orderTotalPrice")]
public 				string

             orderTotalPrice
 { get; set; }
      [JsonProperty("orderSellerPrice")]
public 				string

             orderSellerPrice
 { get; set; }
      [JsonProperty("orderPayment")]
public 				string

             orderPayment
 { get; set; }
      [JsonProperty("freightPrice")]
public 				string

             freightPrice
 { get; set; }
      [JsonProperty("sellerDiscount")]
public 				string

             sellerDiscount
 { get; set; }
      [JsonProperty("orderState")]
public 				string

             orderState
 { get; set; }
      [JsonProperty("orderStateRemark")]
public 				string

             orderStateRemark
 { get; set; }
      [JsonProperty("deliveryType")]
public 				string

             deliveryType
 { get; set; }
      [JsonProperty("invoiceInfo")]
public 				string

             invoiceInfo
 { get; set; }
      [JsonProperty("orderRemark")]
public 				string

             orderRemark
 { get; set; }
      [JsonProperty("orderStartTime")]
public 				string

             orderStartTime
 { get; set; }
      [JsonProperty("orderEndTime")]
public 				string

             orderEndTime
 { get; set; }
      [JsonProperty("consigneeInfo")]
public 				UserInfoFBP

             consigneeInfo
 { get; set; }
      [JsonProperty("itemInfoList")]
public 				List<string>

             itemInfoList
 { get; set; }
      [JsonProperty("modified")]
public 				string

             modified
 { get; set; }
      [JsonProperty("venderRemark")]
public 				string

             venderRemark
 { get; set; }
      [JsonProperty("logisticsNo")]
public 				string

             logisticsNo
 { get; set; }
      [JsonProperty("balanceUsed")]
public 				string

             balanceUsed
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("returnOrder")]
public 				string

             returnOrder
 { get; set; }
      [JsonProperty("paymentConfirmTime")]
public 				string

             paymentConfirmTime
 { get; set; }
      [JsonProperty("waybill")]
public 				string

             waybill
 { get; set; }
      [JsonProperty("logisticsId")]
public 				string

             logisticsId
 { get; set; }
      [JsonProperty("vatInfo")]
public 				VatInfo

             vatInfo
 { get; set; }
      [JsonProperty("parentOrderId")]
public 				string

             parentOrderId
 { get; set; }
      [JsonProperty("orderSource")]
public 				string

             orderSource
 { get; set; }
      [JsonProperty("storeOrder")]
public 				string

             storeOrder
 { get; set; }
      [JsonProperty("customsId")]
public 				string

             customsId
 { get; set; }
      [JsonProperty("customs")]
public 				string

             customs
 { get; set; }
      [JsonProperty("customsModel")]
public 				string

             customsModel
 { get; set; }
      [JsonProperty("orderSign")]
public 				string

             orderSign
 { get; set; }
      [JsonProperty("idSopShipmenttype")]
public 				int

             idSopShipmenttype
 { get; set; }
      [JsonProperty("scDT")]
public 				string

             scDT
 { get; set; }
      [JsonProperty("serviceFee")]
public 				string

             serviceFee
 { get; set; }
      [JsonProperty("couponDetailList")]
public 				List<string>

             couponDetailList
 { get; set; }
      [JsonProperty("directParentOrderId")]
public 				string

             directParentOrderId
 { get; set; }
      [JsonProperty("pauseBizInfo")]
public 				OrderInfoResultPauseBizInfo

             pauseBizInfo
 { get; set; }
      [JsonProperty("taxFee")]
public 				string

             taxFee
 { get; set; }
      [JsonProperty("tuiHuoWuYou")]
public 				string

             tuiHuoWuYou
 { get; set; }
      [JsonProperty("storeId")]
public 				string

             storeId
 { get; set; }
      [JsonProperty("clubId")]
public 				string

             clubId
 { get; set; }
      [JsonProperty("invoiceCode")]
public 				string

             invoiceCode
 { get; set; }
      [JsonProperty("menDianId")]
public 				string

             menDianId
 { get; set; }
	}
}
