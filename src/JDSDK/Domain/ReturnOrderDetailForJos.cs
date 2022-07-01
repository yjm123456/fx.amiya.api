using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReturnOrderDetailForJos:JdObject{
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("commodityName")]
public 				string

             commodityName
 { get; set; }
      [JsonProperty("commodityNum")]
public 				int

             commodityNum
 { get; set; }
	}
}
