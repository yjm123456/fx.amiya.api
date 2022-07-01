using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AreaListBeanVO:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("is3cod")]
public 				string

             is3cod
 { get; set; }
      [JsonProperty("cod")]
public 				bool

             cod
 { get; set; }
	}
}
