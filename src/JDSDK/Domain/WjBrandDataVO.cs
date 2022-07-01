using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WjBrandDataVO:JdObject{
      [JsonProperty("skuid")]
public 				string

             skuid
 { get; set; }
      [JsonProperty("cn")]
public 				string

             cn
 { get; set; }
      [JsonProperty("store")]
public 				string

             store
 { get; set; }
      [JsonProperty("imei")]
public 				string

             imei
 { get; set; }
      [JsonProperty("date")]
public 				string

             date
 { get; set; }
      [JsonProperty("shopid")]
public 				string

             shopid
 { get; set; }
      [JsonProperty("shopname")]
public 				string

             shopname
 { get; set; }
      [JsonProperty("prov")]
public 				string

             prov
 { get; set; }
      [JsonProperty("city")]
public 				string

             city
 { get; set; }
	}
}
