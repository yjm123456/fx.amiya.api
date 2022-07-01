using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class QueryMap:JdObject{
      [JsonProperty("id")]
public 				string

             id
 { get; set; }
      [JsonProperty("buyer_id")]
public 				string

                                                                                     buyerId
 { get; set; }
      [JsonProperty("buyer_name")]
public 				string

                                                                                     buyerName
 { get; set; }
      [JsonProperty("check_time")]
public 				string

                                                                                     checkTime
 { get; set; }
      [JsonProperty("apply_time")]
public 				string

                                                                                     applyTime
 { get; set; }
      [JsonProperty("apply_refund_sum")]
public 				string

                                                                                                                     applyRefundSum
 { get; set; }
      [JsonProperty("status")]
public 				string

             status
 { get; set; }
      [JsonProperty("check_username")]
public 				string

                                                                                     checkUsername
 { get; set; }
      [JsonProperty("order_id")]
public 				string

                                                                                     orderId
 { get; set; }
	}
}
