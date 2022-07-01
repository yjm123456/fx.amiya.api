using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderStatusDetail:JdObject{
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("status_name")]
public 				string

                                                                                     statusName
 { get; set; }
      [JsonProperty("complete_time")]
public 				string

                                                                                     completeTime
 { get; set; }
	}
}
