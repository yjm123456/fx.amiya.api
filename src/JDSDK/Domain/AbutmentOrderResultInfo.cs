using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AbutmentOrderResultInfo:JdObject{
      [JsonProperty("isAuthorized")]
public 				string

             isAuthorized
 { get; set; }
      [JsonProperty("factoryAbutmentOrderDealInfoList")]
public 				List<string>

             factoryAbutmentOrderDealInfoList
 { get; set; }
      [JsonProperty("errorMessage")]
public 				string

             errorMessage
 { get; set; }
	}
}
