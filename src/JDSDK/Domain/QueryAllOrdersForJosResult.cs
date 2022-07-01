using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryAllOrdersForJosResult:JdObject{
      [JsonProperty("customOrderId")]
public 				long

             customOrderId
 { get; set; }
      [JsonProperty("pay")]
public 					string

             pay
 { get; set; }
      [JsonProperty("operatorState")]
public 				int

             operatorState
 { get; set; }
      [JsonProperty("orderState")]
public 				int

             orderState
 { get; set; }
      [JsonProperty("consigneeName")]
public 				string

             consigneeName
 { get; set; }
      [JsonProperty("postcode")]
public 				string

             postcode
 { get; set; }
      [JsonProperty("expectedDeliveryTime")]
public 				DateTime

             expectedDeliveryTime
 { get; set; }
      [JsonProperty("telephone")]
public 				string

             telephone
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("email")]
public 				string

             email
 { get; set; }
      [JsonProperty("address")]
public 				string

             address
 { get; set; }
      [JsonProperty("orderRemark")]
public 				string

             orderRemark
 { get; set; }
      [JsonProperty("orderCreateDate")]
public 				DateTime

             orderCreateDate
 { get; set; }
      [JsonProperty("isNotNotice")]
public 				int

             isNotNotice
 { get; set; }
      [JsonProperty("sendPay")]
public 				string

             sendPay
 { get; set; }
      [JsonProperty("paymentCategory")]
public 				string

             paymentCategory
 { get; set; }
      [JsonProperty("paymentCategoryDispName")]
public 				string

             paymentCategoryDispName
 { get; set; }
      [JsonProperty("createDate")]
public 				DateTime

             createDate
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("refundSourceFlag")]
public 				int

             refundSourceFlag
 { get; set; }
      [JsonProperty("provinceId")]
public 				int

             provinceId
 { get; set; }
      [JsonProperty("provinceName")]
public 				string

             provinceName
 { get; set; }
      [JsonProperty("cityId")]
public 				int

             cityId
 { get; set; }
      [JsonProperty("cityName")]
public 				string

             cityName
 { get; set; }
      [JsonProperty("countyId")]
public 				int

             countyId
 { get; set; }
      [JsonProperty("countyName")]
public 				string

             countyName
 { get; set; }
      [JsonProperty("townId")]
public 				int

             townId
 { get; set; }
      [JsonProperty("townName")]
public 				string

             townName
 { get; set; }
      [JsonProperty("memoByVendor")]
public 				string

             memoByVendor
 { get; set; }
      [JsonProperty("parentOrderId")]
public 				long

             parentOrderId
 { get; set; }
      [JsonProperty("sku")]
public 				string

             sku
 { get; set; }
      [JsonProperty("commodityName")]
public 				string

             commodityName
 { get; set; }
      [JsonProperty("upc")]
public 				string

             upc
 { get; set; }
      [JsonProperty("commodityNum")]
public 				int

             commodityNum
 { get; set; }
      [JsonProperty("jdPrice")]
public 					string

             jdPrice
 { get; set; }
      [JsonProperty("discount")]
public 					string

             discount
 { get; set; }
      [JsonProperty("reduceCount")]
public 					string

             reduceCount
 { get; set; }
      [JsonProperty("totalCarriage")]
public 					string

             totalCarriage
 { get; set; }
      [JsonProperty("cost")]
public 					string

             cost
 { get; set; }
      [JsonProperty("orderDetailList")]
public 				List<string>

             orderDetailList
 { get; set; }
      [JsonProperty("vendorStoreId")]
public 				int

             vendorStoreId
 { get; set; }
      [JsonProperty("vendorStoreName")]
public 				string

             vendorStoreName
 { get; set; }
      [JsonProperty("desen_telephone")]
public 				string

                                                                                     desenTelephone
 { get; set; }
      [JsonProperty("desen_phone")]
public 				string

                                                                                     desenPhone
 { get; set; }
      [JsonProperty("open_id_buyer")]
public 				string

                                                                                                                     openIdBuyer
 { get; set; }
	}
}
