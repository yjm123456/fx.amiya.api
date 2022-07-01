using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttrValueUnlimit:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("attId")]
public 				long

             attId
 { get; set; }
      [JsonProperty("catId")]
public 				long

             catId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("orderSort")]
public 				int

             orderSort
 { get; set; }
      [JsonProperty("features")]
public 				List<string>

             features
 { get; set; }
	}
}
