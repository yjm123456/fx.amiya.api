using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AuditInfoDto:JdObject{
      [JsonProperty("task_id")]
public 				string

                                                                                     taskId
 { get; set; }
      [JsonProperty("approver_code")]
public 				string

                                                                                     approverCode
 { get; set; }
      [JsonProperty("approver_name")]
public 				string

                                                                                     approverName
 { get; set; }
      [JsonProperty("opinion")]
public 				string

             opinion
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("approve_time")]
public 				DateTime

                                                                                     approveTime
 { get; set; }
	}
}
