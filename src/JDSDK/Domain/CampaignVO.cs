using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CampaignVO:JdObject{
      [JsonProperty("budgetType")]
public 				int

             budgetType
 { get; set; }
      [JsonProperty("putType")]
public 				int

             putType
 { get; set; }
      [JsonProperty("timeRangePriceCoef")]
public 				string

             timeRangePriceCoef
 { get; set; }
      [JsonProperty("dayBudgetCustom")]
public 				long

             dayBudgetCustom
 { get; set; }
      [JsonProperty("pin")]
public 				string

             pin
 { get; set; }
      [JsonProperty("yn")]
public 			    short

             yn
 { get; set; }
      [JsonProperty("createdTime")]
public 				DateTime

             createdTime
 { get; set; }
      [JsonProperty("startTime")]
public 				DateTime

             startTime
 { get; set; }
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("dayBudget")]
public 				long

             dayBudget
 { get; set; }
      [JsonProperty("campaignType")]
public 				int

             campaignType
 { get; set; }
      [JsonProperty("overBudgetRatio")]
public 				int

             overBudgetRatio
 { get; set; }
      [JsonProperty("reqType")]
public 				int

             reqType
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("dayBudgetStr")]
public 				string

             dayBudgetStr
 { get; set; }
      [JsonProperty("businessType")]
public 				int

             businessType
 { get; set; }
      [JsonProperty("status")]
public 			    short

             status
 { get; set; }
	}
}
