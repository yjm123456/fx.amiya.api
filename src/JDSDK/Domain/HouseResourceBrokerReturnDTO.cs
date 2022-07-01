using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseResourceBrokerReturnDTO:JdObject{
      [JsonProperty("cityCode")]
public 				int

             cityCode
 { get; set; }
      [JsonProperty("venderId")]
public 				long

             venderId
 { get; set; }
      [JsonProperty("externalId")]
public 				long

             externalId
 { get; set; }
      [JsonProperty("externalBrokerId")]
public 				long

             externalBrokerId
 { get; set; }
      [JsonProperty("houseResourceId")]
public 				long

             houseResourceId
 { get; set; }
      [JsonProperty("quotedPrice")]
public 					string

             quotedPrice
 { get; set; }
      [JsonProperty("recommend")]
public 				int

             recommend
 { get; set; }
      [JsonProperty("orderNum")]
public 				int

             orderNum
 { get; set; }
	}
}
