using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DirectPayDO:JdObject{
      [JsonProperty("purchaseId")]
public 				int

             purchaseId
 { get; set; }
      [JsonProperty("payType")]
public 				int

             payType
 { get; set; }
      [JsonProperty("compensateId")]
public 				int

             compensateId
 { get; set; }
      [JsonProperty("payForSeller")]
public 					string

             payForSeller
 { get; set; }
      [JsonProperty("payState")]
public 				int

             payState
 { get; set; }
      [JsonProperty("created")]
public 				string

             created
 { get; set; }
      [JsonProperty("sellerId")]
public 				int

             sellerId
 { get; set; }
      [JsonProperty("sellerName")]
public 				string

             sellerName
 { get; set; }
      [JsonProperty("payForUser")]
public 					string

             payForUser
 { get; set; }
      [JsonProperty("modified")]
public 				string

             modified
 { get; set; }
	}
}
