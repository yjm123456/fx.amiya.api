using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CartResp:JdObject{
      [JsonProperty("skuResps")]
public 				List<string>

             skuResps
 { get; set; }
      [JsonProperty("suiteResps")]
public 				List<string>

             suiteResps
 { get; set; }
	}
}
