using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AccountBalanceVO:JdObject{
      [JsonProperty("totalAmount")]
public 				double

             totalAmount
 { get; set; }
      [JsonProperty("availableAmount")]
public 				double

             availableAmount
 { get; set; }
      [JsonProperty("freezeAmount")]
public 				double

             freezeAmount
 { get; set; }
	}
}
