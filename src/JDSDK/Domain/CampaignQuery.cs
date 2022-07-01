using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CampaignQuery:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("dayBudget")]
public 				string

             dayBudget
 { get; set; }
      [JsonProperty("dayBudgetStr")]
public 				string

             dayBudgetStr
 { get; set; }
      [JsonProperty("dayBudgetResult")]
public 				double

             dayBudgetResult
 { get; set; }
      [JsonProperty("startTime")]
public 				DateTime

             startTime
 { get; set; }
      [JsonProperty("eneTime")]
public 				DateTime

             eneTime
 { get; set; }
      [JsonProperty("timeRange")]
public 				string

             timeRange
 { get; set; }
      [JsonProperty("status")]
public 				int[]

             status
 { get; set; }
      [JsonProperty("putType")]
public 				int[]

             putType
 { get; set; }
      [JsonProperty("businessType")]
public 				int[]

             businessType
 { get; set; }
	}
}
