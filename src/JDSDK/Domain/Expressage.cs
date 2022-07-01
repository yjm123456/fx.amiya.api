using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Expressage:JdObject{
      [JsonProperty("serviceId")]
public 				int

             serviceId
 { get; set; }
      [JsonProperty("expressCode")]
public 				string

             expressCode
 { get; set; }
      [JsonProperty("expressCompany")]
public 				string

             expressCompany
 { get; set; }
      [JsonProperty("finalFreightMoney")]
public 					string

             finalFreightMoney
 { get; set; }
      [JsonProperty("freightMoney")]
public 					string

             freightMoney
 { get; set; }
      [JsonProperty("modifiedMoney")]
public 					string

             modifiedMoney
 { get; set; }
      [JsonProperty("repeatFreightFlag")]
public 				bool

             repeatFreightFlag
 { get; set; }
      [JsonProperty("deliveryDate")]
public 				DateTime

             deliveryDate
 { get; set; }
      [JsonProperty("firstUploadDate")]
public 				DateTime

             firstUploadDate
 { get; set; }
      [JsonProperty("shipWayId")]
public 				int

             shipWayId
 { get; set; }
      [JsonProperty("freightLogList")]
public 				List<string>

             freightLogList
 { get; set; }
      [JsonProperty("extJsonStr")]
public 				string

             extJsonStr
 { get; set; }
	}
}
