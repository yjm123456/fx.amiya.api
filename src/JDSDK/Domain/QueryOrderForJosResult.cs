using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryOrderForJosResult:JdObject{
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
      [JsonProperty("orderTime")]
public 				DateTime

             orderTime
 { get; set; }
      [JsonProperty("orderRemark")]
public 				string

             orderRemark
 { get; set; }
      [JsonProperty("orderCreateDate")]
public 				DateTime

             orderCreateDate
 { get; set; }
      [JsonProperty("isNotice")]
public 				int

             isNotice
 { get; set; }
      [JsonProperty("sendPay")]
public 				string

             sendPay
 { get; set; }
      [JsonProperty("orderSource")]
public 				string

             orderSource
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
      [JsonProperty("memoByVendor")]
public 				string

             memoByVendor
 { get; set; }
      [JsonProperty("refundSourceFlag")]
public 				int

             refundSourceFlag
 { get; set; }
      [JsonProperty("provinceName")]
public 				string

             provinceName
 { get; set; }
      [JsonProperty("cityName")]
public 				string

             cityName
 { get; set; }
      [JsonProperty("countyName")]
public 				string

             countyName
 { get; set; }
      [JsonProperty("townName")]
public 				string

             townName
 { get; set; }
      [JsonProperty("parentOrderId")]
public 				long

             parentOrderId
 { get; set; }
      [JsonProperty("orderDetailList")]
public 				List<string>

             orderDetailList
 { get; set; }
	}
}
