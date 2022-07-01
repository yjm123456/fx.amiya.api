using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LocCodeInfo:JdObject{
      [JsonProperty("order_id")]
public 				long

                                                                                     orderId
 { get; set; }
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("code_status")]
public 				int

                                                                                     codeStatus
 { get; set; }
      [JsonProperty("order_create_time")]
public 				string

                                                                                                                     orderCreateTime
 { get; set; }
      [JsonProperty("status_modified_time")]
public 				string

                                                                                                                     statusModifiedTime
 { get; set; }
      [JsonProperty("effective_date_start")]
public 				string

                                                                                                                     effectiveDateStart
 { get; set; }
      [JsonProperty("effective_date_end")]
public 				string

                                                                                                                     effectiveDateEnd
 { get; set; }
      [JsonProperty("send_count")]
public 				int

                                                                                     sendCount
 { get; set; }
      [JsonProperty("consume_shop_id")]
public 				string

                                                                                                                     consumeShopId
 { get; set; }
      [JsonProperty("consume_shop_name")]
public 				string

                                                                                                                     consumeShopName
 { get; set; }
      [JsonProperty("order_shop_id")]
public 				string

                                                                                                                     orderShopId
 { get; set; }
      [JsonProperty("order_shop_name")]
public 				string

                                                                                                                     orderShopName
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("phone_num")]
public 				string

                                                                                     phoneNum
 { get; set; }
      [JsonProperty("code_consumed_time")]
public 				string

                                                                                                                     codeConsumedTime
 { get; set; }
      [JsonProperty("card_number")]
public 				string

                                                                                     cardNumber
 { get; set; }
      [JsonProperty("pwd_number")]
public 				string

                                                                                     pwdNumber
 { get; set; }
      [JsonProperty("coupons_amount")]
public 				string

                                                                                     couponsAmount
 { get; set; }
      [JsonProperty("min_consumption")]
public 				string

                                                                                     minConsumption
 { get; set; }
	}
}
