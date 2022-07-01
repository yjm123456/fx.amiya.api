using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CrmMember:JdObject{
      [JsonProperty("customer_pin")]
public 				string

                                                                                     customerPin
 { get; set; }
      [JsonProperty("grade")]
public 				string

             grade
 { get; set; }
      [JsonProperty("trade_count")]
public 				int

                                                                                     tradeCount
 { get; set; }
      [JsonProperty("trade_amount")]
public 					string

                                                                                     tradeAmount
 { get; set; }
      [JsonProperty("close_trade_count")]
public 				int

                                                                                                                     closeTradeCount
 { get; set; }
      [JsonProperty("close_trade_amount")]
public 					string

                                                                                                                     closeTradeAmount
 { get; set; }
      [JsonProperty("item_num")]
public 				int

                                                                                     itemNum
 { get; set; }
      [JsonProperty("avg_price")]
public 					string

                                                                                     avgPrice
 { get; set; }
      [JsonProperty("last_trade_time")]
public 				DateTime

                                                                                                                     lastTradeTime
 { get; set; }
      [JsonProperty("open_id_buyer")]
public 				string

                                                                                                                     openIdBuyer
 { get; set; }
	}
}
