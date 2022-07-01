using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryDto:JdObject{
      [JsonProperty("id")]
public 				int

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("depth")]
public 				int

             depth
 { get; set; }
      [JsonProperty("cid3")]
public 				int

             cid3
 { get; set; }
      [JsonProperty("cid3_name")]
public 				string

                                                                                     cid3Name
 { get; set; }
	}
}
