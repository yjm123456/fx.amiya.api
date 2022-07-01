using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CommodityInfo:JdObject{
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("title")]
public 				string

             title
 { get; set; }
      [JsonProperty("original_title")]
public 				string

                                                                                     originalTitle
 { get; set; }
      [JsonProperty("material_url")]
public 				string

                                                                                     materialUrl
 { get; set; }
      [JsonProperty("target_url")]
public 				string

                                                                                     targetUrl
 { get; set; }
      [JsonProperty("price")]
public 					string

             price
 { get; set; }
      [JsonProperty("material_label")]
public 				MaterialLabelVO

                                                                                     materialLabel
 { get; set; }
      [JsonProperty("material_spu")]
public 				List<string>

                                                                                     materialSpu
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("plan_id")]
public 				long

                                                                                     planId
 { get; set; }
      [JsonProperty("space_id")]
public 				long

                                                                                     spaceId
 { get; set; }
      [JsonProperty("review_status")]
public 				int

                                                                                     reviewStatus
 { get; set; }
      [JsonProperty("review_mark")]
public 				string

                                                                                     reviewMark
 { get; set; }
      [JsonProperty("show_days")]
public 				int

                                                                                     showDays
 { get; set; }
	}
}
