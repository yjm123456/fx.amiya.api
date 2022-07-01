using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BWareInfoDto:JdObject{
      [JsonProperty("spuInfo")]
public 				BSpuInfoDto

             spuInfo
 { get; set; }
      [JsonProperty("spuExtendInfo")]
public 				BSpuExtendInfoDto

             spuExtendInfo
 { get; set; }
      [JsonProperty("bSpuAttrs")]
public 				List<string>

             bSpuAttrs
 { get; set; }
      [JsonProperty("bSpuQualifies")]
public 				List<string>

             bSpuQualifies
 { get; set; }
      [JsonProperty("bSpuImages")]
public 				List<string>

             bSpuImages
 { get; set; }
      [JsonProperty("skuInfo")]
public 				List<string>

             skuInfo
 { get; set; }
	}
}
