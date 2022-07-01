using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PromoSkuVO:JdObject{
      [JsonProperty("ware_id")]
public 				long

                                                                                     wareId
 { get; set; }
      [JsonProperty("item_num")]
public 				string

                                                                                     itemNum
 { get; set; }
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("sku_name")]
public 				string

                                                                                     skuName
 { get; set; }
      [JsonProperty("promo_id")]
public 				long

                                                                                     promoId
 { get; set; }
      [JsonProperty("jd_price")]
public 				string

                                                                                     jdPrice
 { get; set; }
      [JsonProperty("promo_price")]
public 				string

                                                                                     promoPrice
 { get; set; }
      [JsonProperty("seq")]
public 				int

             seq
 { get; set; }
      [JsonProperty("num")]
public 				int

             num
 { get; set; }
      [JsonProperty("bind_type")]
public 				int

                                                                                     bindType
 { get; set; }
      [JsonProperty("rfId")]
public 				long

             rfId
 { get; set; }
	}
}
