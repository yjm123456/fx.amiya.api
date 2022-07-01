using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AdGroupAutomatedBiddingDTO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("adGroupId")]
public 				long

             adGroupId
 { get; set; }
      [JsonProperty("retrievalType")]
public 				int

             retrievalType
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("tcpaBid")]
public 				string

             tcpaBid
 { get; set; }
      [JsonProperty("biddingType")]
public 				int

             biddingType
 { get; set; }
      [JsonProperty("tcpaMode")]
public 				int

             tcpaMode
 { get; set; }
	}
}
