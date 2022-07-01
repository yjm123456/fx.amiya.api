using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TempComplete:JdObject{
      [JsonProperty("afsServiceId")]
public 				int

             afsServiceId
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("wareName")]
public 				string

             wareName
 { get; set; }
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("afsServiceProcessResult")]
public 				int

             afsServiceProcessResult
 { get; set; }
      [JsonProperty("afsServiceProcessResultName")]
public 				string

             afsServiceProcessResultName
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
      [JsonProperty("processDate")]
public 				DateTime

             processDate
 { get; set; }
      [JsonProperty("processPin")]
public 				string

             processPin
 { get; set; }
      [JsonProperty("afsDetailType")]
public 				int

             afsDetailType
 { get; set; }
      [JsonProperty("customerGrade")]
public 				int

             customerGrade
 { get; set; }
      [JsonProperty("customerMobilePhone")]
public 				string

             customerMobilePhone
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
 { get; set; }
      [JsonProperty("approveResonCid1")]
public 				int

             approveResonCid1
 { get; set; }
      [JsonProperty("approveResonCid2")]
public 				int

             approveResonCid2
 { get; set; }
      [JsonProperty("afsServiceState")]
public 				int

             afsServiceState
 { get; set; }
      [JsonProperty("afsCategoryId")]
public 				int

             afsCategoryId
 { get; set; }
	}
}
