using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SuiteResp:JdObject{
      [JsonProperty("suiteId")]
public 				long

             suiteId
 { get; set; }
      [JsonProperty("suiteType")]
public 				int

             suiteType
 { get; set; }
      [JsonProperty("suiteName")]
public 				string

             suiteName
 { get; set; }
      [JsonProperty("suiteNum")]
public 				int

             suiteNum
 { get; set; }
      [JsonProperty("promotionId")]
public 				long

             promotionId
 { get; set; }
      [JsonProperty("promotionType")]
public 				int

             promotionType
 { get; set; }
      [JsonProperty("skuItems")]
public 				List<string>

             skuItems
 { get; set; }
      [JsonProperty("giftItems")]
public 				List<string>

             giftItems
 { get; set; }
      [JsonProperty("manMoney")]
public 					string

             manMoney
 { get; set; }
	}
}
