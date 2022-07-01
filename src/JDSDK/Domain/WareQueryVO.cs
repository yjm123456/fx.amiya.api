using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareQueryVO:JdObject{
      [JsonProperty("wareId")]
public 				long

             wareId
 { get; set; }
      [JsonProperty("wareStatus")]
public 				int

             wareStatus
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("itemNum")]
public 				string

             itemNum
 { get; set; }
      [JsonProperty("transportId")]
public 				int

             transportId
 { get; set; }
      [JsonProperty("onlineTime")]
public 				DateTime

             onlineTime
 { get; set; }
      [JsonProperty("minSupplyPrice")]
public 				string

             minSupplyPrice
 { get; set; }
      [JsonProperty("maxSupplyPrice")]
public 				string

             maxSupplyPrice
 { get; set; }
      [JsonProperty("recommendTpid")]
public 				int

             recommendTpid
 { get; set; }
	}
}
