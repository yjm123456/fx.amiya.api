using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SpaceInfo:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("detail")]
public 				string

             detail
 { get; set; }
      [JsonProperty("page_id")]
public 				long

                                                                                     pageId
 { get; set; }
      [JsonProperty("width")]
public 				int

             width
 { get; set; }
      [JsonProperty("height")]
public 				int

             height
 { get; set; }
      [JsonProperty("traffic")]
public 				int

             traffic
 { get; set; }
      [JsonProperty("style")]
public 				int

             style
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
	}
}
