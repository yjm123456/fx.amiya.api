using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ProviderDTO:JdObject{
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("providerName")]
public 				string

             providerName
 { get; set; }
      [JsonProperty("providerType")]
public 				byte

             providerType
 { get; set; }
      [JsonProperty("operationType")]
public 				byte

             operationType
 { get; set; }
      [JsonProperty("rangeType")]
public 				byte

             rangeType
 { get; set; }
      [JsonProperty("contactName")]
public 				string

             contactName
 { get; set; }
      [JsonProperty("contactPhone")]
public 				string

             contactPhone
 { get; set; }
      [JsonProperty("contactMobile")]
public 				string

             contactMobile
 { get; set; }
      [JsonProperty("inPlatform")]
public 				bool

             inPlatform
 { get; set; }
      [JsonProperty("supportCod")]
public 				bool

             supportCod
 { get; set; }
      [JsonProperty("approveState")]
public 				byte

             approveState
 { get; set; }
      [JsonProperty("approveComment")]
public 				string

             approveComment
 { get; set; }
      [JsonProperty("providerState")]
public 				byte

             providerState
 { get; set; }
	}
}
