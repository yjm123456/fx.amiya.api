using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReceiveDetail:JdObject{
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("receiveId")]
public 				int

             receiveId
 { get; set; }
      [JsonProperty("receiveType")]
public 				int

             receiveType
 { get; set; }
      [JsonProperty("receiveTypeName")]
public 				string

             receiveTypeName
 { get; set; }
      [JsonProperty("receiveDate")]
public 				DateTime

             receiveDate
 { get; set; }
      [JsonProperty("partCode")]
public 				string

             partCode
 { get; set; }
      [JsonProperty("packingState")]
public 				int

             packingState
 { get; set; }
      [JsonProperty("packingStateName")]
public 				string

             packingStateName
 { get; set; }
      [JsonProperty("qualityState")]
public 				int

             qualityState
 { get; set; }
      [JsonProperty("qualityStateName")]
public 				string

             qualityStateName
 { get; set; }
      [JsonProperty("appearanceState")]
public 				int

             appearanceState
 { get; set; }
      [JsonProperty("appearanceStateName")]
public 				string

             appearanceStateName
 { get; set; }
      [JsonProperty("invoiceRecordState")]
public 				int

             invoiceRecordState
 { get; set; }
      [JsonProperty("invoiceRecordStateName")]
public 				string

             invoiceRecordStateName
 { get; set; }
      [JsonProperty("judgmentReason")]
public 				int

             judgmentReason
 { get; set; }
      [JsonProperty("judgmentReasonName")]
public 				string

             judgmentReasonName
 { get; set; }
      [JsonProperty("accessoryOrGift")]
public 				int

             accessoryOrGift
 { get; set; }
      [JsonProperty("accessoryOrGiftName")]
public 				string

             accessoryOrGiftName
 { get; set; }
      [JsonProperty("receiveRemark")]
public 				string

             receiveRemark
 { get; set; }
      [JsonProperty("abnormalFlag")]
public 				bool

             abnormalFlag
 { get; set; }
      [JsonProperty("receiveWareList")]
public 				List<string>

             receiveWareList
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
