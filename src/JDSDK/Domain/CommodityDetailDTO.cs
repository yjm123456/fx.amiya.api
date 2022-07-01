using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CommodityDetailDTO:JdObject{
      [JsonProperty("detail_id")]
public 				int

                                                                                     detailId
 { get; set; }
      [JsonProperty("product_id")]
public 				string

                                                                                     productId
 { get; set; }
      [JsonProperty("product_num")]
public 				int

                                                                                     productNum
 { get; set; }
      [JsonProperty("product")]
public 				string

             product
 { get; set; }
      [JsonProperty("product_format")]
public 				string

                                                                                     productFormat
 { get; set; }
      [JsonProperty("product_unit")]
public 				string

                                                                                     productUnit
 { get; set; }
      [JsonProperty("product_price")]
public 					string

                                                                                     productPrice
 { get; set; }
      [JsonProperty("detail_amount")]
public 					string

                                                                                     detailAmount
 { get; set; }
      [JsonProperty("product_brand")]
public 				string

                                                                                     productBrand
 { get; set; }
      [JsonProperty("quality_type")]
public 				int

                                                                                     qualityType
 { get; set; }
      [JsonProperty("quality_name")]
public 				string

                                                                                     qualityName
 { get; set; }
      [JsonProperty("oe_num")]
public 				string

                                                                                     oeNum
 { get; set; }
      [JsonProperty("pop_product_key")]
public 				string

                                                                                                                     popProductKey
 { get; set; }
	}
}
