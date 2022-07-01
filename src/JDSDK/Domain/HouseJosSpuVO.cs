using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseJosSpuVO:JdObject{
      [JsonProperty("spuId")]
public 				long

             spuId
 { get; set; }
      [JsonProperty("spuName")]
public 				string

             spuName
 { get; set; }
      [JsonProperty("spuFlag")]
public 				int

             spuFlag
 { get; set; }
      [JsonProperty("firstCode")]
public 				int

             firstCode
 { get; set; }
      [JsonProperty("secondCode")]
public 				int

             secondCode
 { get; set; }
      [JsonProperty("thirdCode")]
public 				int

             thirdCode
 { get; set; }
      [JsonProperty("firstName")]
public 				string

             firstName
 { get; set; }
      [JsonProperty("secondName")]
public 				string

             secondName
 { get; set; }
      [JsonProperty("thirdName")]
public 				string

             thirdName
 { get; set; }
	}
}
