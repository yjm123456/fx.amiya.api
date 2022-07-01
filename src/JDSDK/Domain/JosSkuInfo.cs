using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosSkuInfo:JdObject{
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("sku_url")]
public 				string

                                                                                     skuUrl
 { get; set; }
	}
}
