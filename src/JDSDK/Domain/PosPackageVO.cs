using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PosPackageVO:JdObject{
      [JsonProperty("CTR")]
public 				string

             CTR
 { get; set; }
      [JsonProperty("description")]
public 				string

             description
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("adScreenShot")]
public 				string

             adScreenShot
 { get; set; }
      [JsonProperty("star")]
public 				int

             star
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("reqType")]
public 				int

             reqType
 { get; set; }
      [JsonProperty("device")]
public 				int

             device
 { get; set; }
	}
}
