using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SpacePageInfo:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("available")]
public 				int

             available
 { get; set; }
      [JsonProperty("category_name")]
public 				string

                                                                                     categoryName
 { get; set; }
      [JsonProperty("parent_id")]
public 				long

                                                                                     parentId
 { get; set; }
      [JsonProperty("url")]
public 				string

             url
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
	}
}
