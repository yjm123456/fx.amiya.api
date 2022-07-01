using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DaJiaDianInstallVO:JdObject{
      [JsonProperty("productName")]
public 				string

             productName
 { get; set; }
      [JsonProperty("productId")]
public 				string

             productId
 { get; set; }
      [JsonProperty("installNumber")]
public 				string

             installNumber
 { get; set; }
      [JsonProperty("installInfo")]
public 				List<string>

             installInfo
 { get; set; }
	}
}
