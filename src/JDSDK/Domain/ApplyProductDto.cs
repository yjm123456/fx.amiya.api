using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ApplyProductDto:JdObject{
      [JsonProperty("apply_id")]
public 				string

                                                                                     applyId
 { get; set; }
      [JsonProperty("wareId")]
public 				string

             wareId
 { get; set; }
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
      [JsonProperty("submit_time")]
public 				string

                                                                                     submitTime
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
	}
}
