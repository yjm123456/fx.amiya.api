using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CommoditySpu:JdObject{
      [JsonProperty("material_id")]
public 				long

                                                                                     materialId
 { get; set; }
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("image_url")]
public 				string

                                                                                     imageUrl
 { get; set; }
	}
}
