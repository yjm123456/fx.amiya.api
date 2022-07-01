using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class VenderBrandPubInfo:JdObject{
      [JsonProperty("erpBrandId")]
public 				int

             erpBrandId
 { get; set; }
      [JsonProperty("brandName")]
public 				string

             brandName
 { get; set; }
	}
}
