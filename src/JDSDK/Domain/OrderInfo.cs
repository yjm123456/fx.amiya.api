using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderInfo:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("orderType")]
public 				int

             orderType
 { get; set; }
      [JsonProperty("orderTotalFee")]
public 				long

             orderTotalFee
 { get; set; }
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
      [JsonProperty("userPin")]
public 				string

             userPin
 { get; set; }
      [JsonProperty("payTime")]
public 				DateTime

             payTime
 { get; set; }
      [JsonProperty("createTime")]
public 				DateTime

             createTime
 { get; set; }
	}
}
