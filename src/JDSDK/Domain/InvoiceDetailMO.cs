using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class InvoiceDetailMO:JdObject{
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("skuId")]
public 				string

             skuId
 { get; set; }
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("happenTime")]
public 				DateTime

             happenTime
 { get; set; }
      [JsonProperty("orderFinishTime")]
public 				DateTime

             orderFinishTime
 { get; set; }
      [JsonProperty("feeName")]
public 				string

             feeName
 { get; set; }
      [JsonProperty("settleBal")]
public 					string

             settleBal
 { get; set; }
	}
}
