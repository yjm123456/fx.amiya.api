using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosPromotionSku:JdObject{
      [JsonProperty("promo_sku_id")]
public 				long

                                                                                                                     promoSkuId
 { get; set; }
      [JsonProperty("ware_id")]
public 				long

                                                                                     wareId
 { get; set; }
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("sku_name")]
public 				string

                                                                                     skuName
 { get; set; }
      [JsonProperty("bind_type")]
public 				int

                                                                                     bindType
 { get; set; }
      [JsonProperty("jd_price")]
public 				string

                                                                                     jdPrice
 { get; set; }
      [JsonProperty("promo_price")]
public 				string

                                                                                     promoPrice
 { get; set; }
      [JsonProperty("item_num")]
public 				string

                                                                                     itemNum
 { get; set; }
      [JsonProperty("limit_num")]
public 				int

                                                                                     limitNum
 { get; set; }
      [JsonProperty("sku_status")]
public 				int

                                                                                     skuStatus
 { get; set; }
      [JsonProperty("seq")]
public 				int

             seq
 { get; set; }
      [JsonProperty("display")]
public 				int

             display
 { get; set; }
      [JsonProperty("is_need_to_buy")]
public 				int

                                                                                                                                                     isNeedToBuy
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
      [JsonProperty("rfId")]
public 				long

             rfId
 { get; set; }
	}
}
