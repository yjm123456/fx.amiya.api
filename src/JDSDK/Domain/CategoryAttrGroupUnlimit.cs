using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryAttrGroupUnlimit:JdObject{
      [JsonProperty("id")]
public 				long

             id
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
