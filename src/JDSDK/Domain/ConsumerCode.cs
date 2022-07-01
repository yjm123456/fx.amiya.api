using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ConsumerCode:JdObject{
      [JsonProperty("order_id")]
public 				long

                                                                                     orderId
 { get; set; }
      [JsonProperty("code_num")]
public 				string

                                                                                     codeNum
 { get; set; }
      [JsonProperty("sku_id")]
public 				long

                                                                                     skuId
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("effective_date")]
public 				DateTime

                                                                                     effectiveDate
 { get; set; }
      [JsonProperty("send_count")]
public 				int

                                                                                     sendCount
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("consumer_status")]
public 				int

                                                                                     consumerStatus
 { get; set; }
      [JsonProperty("consumer_time")]
public 				DateTime

                                                                                     consumerTime
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
