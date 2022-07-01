using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CreateOrderVo:JdObject{
      [JsonProperty("order_sn")]
public 				string

                                                                                     orderSn
 { get; set; }
      [JsonProperty("payment_name")]
public 				string

                                                                                     paymentName
 { get; set; }
      [JsonProperty("shipping_name")]
public 				string

                                                                                     shippingName
 { get; set; }
      [JsonProperty("order_amount")]
public 					string

                                                                                     orderAmount
 { get; set; }
	}
}
