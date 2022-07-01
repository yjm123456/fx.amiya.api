using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Category:JdObject{
      [JsonProperty("fid")]
public 				int

             fid
 { get; set; }
      [JsonProperty("aliasName")]
public 				string

             aliasName
 { get; set; }
      [JsonProperty("featureMap")]
public 					Dictionary<string, object>

             featureMap
 { get; set; }
      [JsonProperty("notes")]
public 				string

             notes
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("features")]
public 				string

             features
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("indexId")]
public 				int

             indexId
 { get; set; }
      [JsonProperty("logo")]
public 				string

             logo
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
      [JsonProperty("lev")]
public 				int

             lev
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
