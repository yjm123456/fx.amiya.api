using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosSalesInfoDto:JdObject{
      [JsonProperty("vendorCode")]
public 				string

             vendorCode
 { get; set; }
      [JsonProperty("deliverCenterCode")]
public 				string

             deliverCenterCode
 { get; set; }
      [JsonProperty("jdSku")]
public 				string

             jdSku
 { get; set; }
      [JsonProperty("salesVolume")]
public 				string

             salesVolume
 { get; set; }
      [JsonProperty("days")]
public 				int

             days
 { get; set; }
	}
}
