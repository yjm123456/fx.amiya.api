using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderSubmitResponse:JdObject{
      [JsonProperty("orderCode")]
public 				string

             orderCode
 { get; set; }
      [JsonProperty("fxOrderCode")]
public 				string

             fxOrderCode
 { get; set; }
      [JsonProperty("jdOrderCode")]
public 				string

             jdOrderCode
 { get; set; }
      [JsonProperty("skus")]
public 				List<string>

             skus
 { get; set; }
      [JsonProperty("errorSkus")]
public 				List<string>

             errorSkus
 { get; set; }
      [JsonProperty("freightFee")]
public 					string

             freightFee
 { get; set; }
      [JsonProperty("rebate")]
public 					string

             rebate
 { get; set; }
      [JsonProperty("shouldPay")]
public 					string

             shouldPay
 { get; set; }
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
	}
}
