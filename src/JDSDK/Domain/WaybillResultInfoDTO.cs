using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WaybillResultInfoDTO:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("resultMessage")]
public 				string

             resultMessage
 { get; set; }
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("deliveryId")]
public 				string

             deliveryId
 { get; set; }
      [JsonProperty("promiseTimeType")]
public 				int

             promiseTimeType
 { get; set; }
      [JsonProperty("preSortResult")]
public 				PreSortResult

             preSortResult
 { get; set; }
      [JsonProperty("transType")]
public 				int

             transType
 { get; set; }
      [JsonProperty("needRetry")]
public 				bool

             needRetry
 { get; set; }
      [JsonProperty("expressOperationMode")]
public 				int

             expressOperationMode
 { get; set; }
	}
}
