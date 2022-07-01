using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CoCreateLwbResultForCreateWbOrder:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
      [JsonProperty("wbNo")]
public 				string

             wbNo
 { get; set; }
      [JsonProperty("lwbNo")]
public 				string

             lwbNo
 { get; set; }
      [JsonProperty("deliveryMthd")]
public 				byte

             deliveryMthd
 { get; set; }
      [JsonProperty("providerName")]
public 				string

             providerName
 { get; set; }
      [JsonProperty("thrOrderId")]
public 				string

             thrOrderId
 { get; set; }
      [JsonProperty("providerCode")]
public 				string

             providerCode
 { get; set; }
      [JsonProperty("resultForLwbMainList")]
public 				List<string>

             resultForLwbMainList
 { get; set; }
	}
}
