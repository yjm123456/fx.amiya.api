using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class IncomeResultVO:JdObject{
      [JsonProperty("swiftNumber")]
public 				string

             swiftNumber
 { get; set; }
      [JsonProperty("amount")]
public 					string

             amount
 { get; set; }
      [JsonProperty("createTime")]
public 				string

             createTime
 { get; set; }
	}
}
