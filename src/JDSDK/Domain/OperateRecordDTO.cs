using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OperateRecordDTO:JdObject{
      [JsonProperty("operateText")]
public 				string

             operateText
 { get; set; }
      [JsonProperty("operateTime")]
public 				DateTime

             operateTime
 { get; set; }
      [JsonProperty("operateUser")]
public 				string

             operateUser
 { get; set; }
      [JsonProperty("orderStatus")]
public 				int

             orderStatus
 { get; set; }
	}
}
