using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class TwoOrderValueServiceVO:JdObject{
      [JsonProperty("twoOrderId")]
public 				long

             twoOrderId
 { get; set; }
      [JsonProperty("serviceId")]
public 				long

             serviceId
 { get; set; }
      [JsonProperty("serviceName")]
public 				string

             serviceName
 { get; set; }
      [JsonProperty("serviceFee")]
public 				long

             serviceFee
 { get; set; }
      [JsonProperty("serviceRemark")]
public 				string

             serviceRemark
 { get; set; }
      [JsonProperty("returnAmount")]
public 				long

             returnAmount
 { get; set; }
      [JsonProperty("actualAmount")]
public 				long

             actualAmount
 { get; set; }
      [JsonProperty("extStr")]
public 				string

             extStr
 { get; set; }
	}
}
