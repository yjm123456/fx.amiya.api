using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PayInfoDTO:JdObject{
      [JsonProperty("orderId")]
public 				string

             orderId
 { get; set; }
      [JsonProperty("sign")]
public 				string

             sign
 { get; set; }
      [JsonProperty("reqInfo")]
public 				string

             reqInfo
 { get; set; }
      [JsonProperty("payUrl")]
public 				string

             payUrl
 { get; set; }
	}
}
