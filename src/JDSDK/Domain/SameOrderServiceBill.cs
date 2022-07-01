using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SameOrderServiceBill:JdObject{
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("serviceState")]
public 				int

             serviceState
 { get; set; }
      [JsonProperty("serviceStateName")]
public 				string

             serviceStateName
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
      [JsonProperty("approveReasonCid1")]
public 				int

             approveReasonCid1
 { get; set; }
      [JsonProperty("approveReasonCid1Name")]
public 				string

             approveReasonCid1Name
 { get; set; }
      [JsonProperty("approveReasonCid2")]
public 				int

             approveReasonCid2
 { get; set; }
      [JsonProperty("approveReasonCid2Name")]
public 				string

             approveReasonCid2Name
 { get; set; }
      [JsonProperty("approvedResult")]
public 				int

             approvedResult
 { get; set; }
      [JsonProperty("approvedResultName")]
public 				string

             approvedResultName
 { get; set; }
      [JsonProperty("approvePin")]
public 				string

             approvePin
 { get; set; }
      [JsonProperty("approveName")]
public 				string

             approveName
 { get; set; }
      [JsonProperty("approvedDate")]
public 				DateTime

             approvedDate
 { get; set; }
      [JsonProperty("processPin")]
public 				string

             processPin
 { get; set; }
      [JsonProperty("processName")]
public 				string

             processName
 { get; set; }
      [JsonProperty("processedDate")]
public 				DateTime

             processedDate
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
