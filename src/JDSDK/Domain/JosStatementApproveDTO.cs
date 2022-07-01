using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosStatementApproveDTO:JdObject{
      [JsonProperty("approveTime")]
public 				DateTime

             approveTime
 { get; set; }
      [JsonProperty("approveJobName")]
public 				string

             approveJobName
 { get; set; }
      [JsonProperty("approveStatus")]
public 				int

             approveStatus
 { get; set; }
	}
}
