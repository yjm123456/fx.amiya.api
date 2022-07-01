using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LwbMainStatusFull:JdObject{
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
      [JsonProperty("lwbNo")]
public 				string

             lwbNo
 { get; set; }
      [JsonProperty("lwbStatusInfo")]
public 				List<string>

             lwbStatusInfo
 { get; set; }
	}
}
