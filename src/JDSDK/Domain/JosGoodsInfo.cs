using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosGoodsInfo:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("wp_name")]
public 				string

                                                                                     wpName
 { get; set; }
      [JsonProperty("image_url")]
public 				string

                                                                                     imageUrl
 { get; set; }
      [JsonProperty("w_name")]
public 				string

                                                                                     wName
 { get; set; }
      [JsonProperty("wp_id")]
public 				long

                                                                                     wpId
 { get; set; }
      [JsonProperty("class_names")]
public 				string

                                                                                     classNames
 { get; set; }
      [JsonProperty("class_ids")]
public 				int

                                                                                     classIds
 { get; set; }
      [JsonProperty("image_urls")]
public 				string

                                                                                     imageUrls
 { get; set; }
      [JsonProperty("sku_similars")]
public 				List<string>

                                                                                     skuSimilars
 { get; set; }
	}
}
