using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsApplyWaitFetch:JdObject{
      [JsonProperty("afsApplyId")]
public 				int

             afsApplyId
 { get; set; }
      [JsonProperty("customerPin")]
public 				string

             customerPin
 { get; set; }
      [JsonProperty("customerName")]
public 				string

             customerName
 { get; set; }
      [JsonProperty("customerMobilePhone")]
public 				string

             customerMobilePhone
 { get; set; }
      [JsonProperty("pickwareAddress")]
public 				string

             pickwareAddress
 { get; set; }
      [JsonProperty("afsApplyTime")]
public 				DateTime

             afsApplyTime
 { get; set; }
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
	}
}
