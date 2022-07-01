using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareTemplate:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("bottomContent")]
public 				string

             bottomContent
 { get; set; }
      [JsonProperty("headContent")]
public 				string

             headContent
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("refCount")]
public 				int

             refCount
 { get; set; }
      [JsonProperty("mobileBottomContent")]
public 				string

             mobileBottomContent
 { get; set; }
      [JsonProperty("mobileHeadContent")]
public 				string

             mobileHeadContent
 { get; set; }
	}
}
