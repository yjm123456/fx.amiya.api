using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PaymentNoResult:JdObject{
      [JsonProperty("orderId")]
public 				long

             orderId
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("paymentNo")]
public 				string

             paymentNo
 { get; set; }
      [JsonProperty("parentPaymentNo")]
public 				string

             parentPaymentNo
 { get; set; }
	}
}
