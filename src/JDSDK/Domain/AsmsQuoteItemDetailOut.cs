using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AsmsQuoteItemDetailOut:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("materialName")]
public 				string

             materialName
 { get; set; }
      [JsonProperty("materialPrice")]
public 					string

             materialPrice
 { get; set; }
      [JsonProperty("materialUnit")]
public 				string

             materialUnit
 { get; set; }
      [JsonProperty("materialDesc")]
public 				string

             materialDesc
 { get; set; }
      [JsonProperty("materialCode")]
public 				string

             materialCode
 { get; set; }
	}
}
