using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SplitOrderResultDto:JdObject{
      [JsonProperty("customOrderId")]
public 				long

             customOrderId
 { get; set; }
      [JsonProperty("groupId")]
public 				int

             groupId
 { get; set; }
	}
}
