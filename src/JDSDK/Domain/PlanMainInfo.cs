using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PlanMainInfo:JdObject{
      [JsonProperty("id")]
public 				long

             id
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("space_id")]
public 				long

                                                                                     spaceId
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
      [JsonProperty("budget")]
public 					string

             budget
 { get; set; }
      [JsonProperty("total_budget")]
public 					string

                                                                                     totalBudget
 { get; set; }
      [JsonProperty("mode")]
public 				int

             mode
 { get; set; }
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("status_name")]
public 				string

                                                                                     statusName
 { get; set; }
      [JsonProperty("allow_split")]
public 				int

                                                                                     allowSplit
 { get; set; }
      [JsonProperty("schedule_start")]
public 				string

                                                                                     scheduleStart
 { get; set; }
      [JsonProperty("schedule_end")]
public 				string

                                                                                     scheduleEnd
 { get; set; }
      [JsonProperty("insert_time")]
public 				string

                                                                                     insertTime
 { get; set; }
      [JsonProperty("update_time")]
public 				string

                                                                                     updateTime
 { get; set; }
      [JsonProperty("submit_time")]
public 				string

                                                                                     submitTime
 { get; set; }
      [JsonProperty("show_type")]
public 				int

                                                                                     showType
 { get; set; }
      [JsonProperty("bid_status")]
public 				int

                                                                                     bidStatus
 { get; set; }
      [JsonProperty("ad_space_name")]
public 				string

                                                                                                                     adSpaceName
 { get; set; }
	}
}
