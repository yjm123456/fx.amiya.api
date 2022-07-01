using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReturnOrderPreForJosResult:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("customOrderId")]
public 				long

             customOrderId
 { get; set; }
      [JsonProperty("roApplyFee")]
public 					string

             roApplyFee
 { get; set; }
      [JsonProperty("roApplyDate")]
public 				DateTime

             roApplyDate
 { get; set; }
      [JsonProperty("orderCreateDate")]
public 				DateTime

             orderCreateDate
 { get; set; }
      [JsonProperty("modifiedDate")]
public 				DateTime

             modifiedDate
 { get; set; }
      [JsonProperty("approvalState")]
public 				int

             approvalState
 { get; set; }
      [JsonProperty("orderState")]
public 				int

             orderState
 { get; set; }
      [JsonProperty("operatorState")]
public 				int

             operatorState
 { get; set; }
      [JsonProperty("roPreNo")]
public 				long

             roPreNo
 { get; set; }
      [JsonProperty("roAccount")]
public 				string

             roAccount
 { get; set; }
      [JsonProperty("roReason")]
public 				string

             roReason
 { get; set; }
      [JsonProperty("approvalSuggestion")]
public 				string

             approvalSuggestion
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
	}
}
