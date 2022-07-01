using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderinfoProductResponse:JdObject{
      [JsonProperty("order_id")]
public 				string

                                                                                     orderId
 { get; set; }
      [JsonProperty("sku_id")]
public 				string

                                                                                     skuId
 { get; set; }
      [JsonProperty("outer_sku_id")]
public 				string

                                                                                                                     outerSkuId
 { get; set; }
      [JsonProperty("sku_name")]
public 				string

                                                                                     skuName
 { get; set; }
      [JsonProperty("jd_price")]
public 				double

                                                                                     jdPrice
 { get; set; }
      [JsonProperty("gift_point")]
public 				int

                                                                                     giftPoint
 { get; set; }
      [JsonProperty("ware_id")]
public 				string

                                                                                     wareId
 { get; set; }
      [JsonProperty("item_total")]
public 				int

                                                                                     itemTotal
 { get; set; }
      [JsonProperty("stock_owner")]
public 				string

                                                                                     stockOwner
 { get; set; }
	}
}
