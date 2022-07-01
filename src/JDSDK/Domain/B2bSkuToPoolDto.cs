using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class B2bSkuToPoolDto:JdObject{
      [JsonProperty("creator")]
public 				string

             creator
 { get; set; }
      [JsonProperty("jdSkuId")]
public 				long

             jdSkuId
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("b2bPoolId")]
public 				long

             b2bPoolId
 { get; set; }
	}
}
