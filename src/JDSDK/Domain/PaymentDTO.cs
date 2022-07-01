using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PaymentDTO:JdObject{
      [JsonProperty("orderSellerPrice")]
public 					string

             orderSellerPrice
 { get; set; }
      [JsonProperty("orderPayment")]
public 					string

             orderPayment
 { get; set; }
      [JsonProperty("freightPrice")]
public 					string

             freightPrice
 { get; set; }
      [JsonProperty("discount")]
public 					string

             discount
 { get; set; }
	}
}
