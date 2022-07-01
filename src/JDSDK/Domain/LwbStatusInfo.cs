using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class LwbStatusInfo:JdObject{
      [JsonProperty("status")]
public 				int

             status
 { get; set; }
      [JsonProperty("operator")]
public 				string

             operator1
 { get; set; }
      [JsonProperty("operation")]
public 				string

             operation
 { get; set; }
      [JsonProperty("operateSystem")]
public 				string

             operateSystem
 { get; set; }
      [JsonProperty("operateDate")]
public 				DateTime

             operateDate
 { get; set; }
	}
}
