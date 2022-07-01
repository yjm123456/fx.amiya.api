using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderPaymentResp:JdObject{
      [JsonProperty("payCompleteTime")]
public 				DateTime

             payCompleteTime
 { get; set; }
      [JsonProperty("paymentType")]
public 				int

             paymentType
 { get; set; }
      [JsonProperty("delayPay")]
public 					bool

             delayPay
 { get; set; }
      [JsonProperty("additionalPayments")]
public 				List<string>

             additionalPayments
 { get; set; }
	}
}
