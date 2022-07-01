using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReturnGoodsDetailVo:JdObject{
      [JsonProperty("product_sn")]
public 				string

                                                                                     productSn
 { get; set; }
      [JsonProperty("product")]
public 				string

             product
 { get; set; }
      [JsonProperty("product_format")]
public 				string

                                                                                     productFormat
 { get; set; }
      [JsonProperty("product_num")]
public 				int

                                                                                     productNum
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
      [JsonProperty("return_reason")]
public 				string

                                                                                     returnReason
 { get; set; }
      [JsonProperty("return_desc")]
public 				string

                                                                                     returnDesc
 { get; set; }
      [JsonProperty("card_url")]
public 				string

                                                                                     cardUrl
 { get; set; }
	}
}
