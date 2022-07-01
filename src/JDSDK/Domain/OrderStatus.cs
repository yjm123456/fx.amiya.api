using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OrderStatus:JdObject{
      [JsonProperty("soStatusCode")]
public 				int[]

             soStatusCode
 { get; set; }
      [JsonProperty("soStatusName")]
public 				string

             soStatusName
 { get; set; }
      [JsonProperty("operateTime")]
public 				string

             operateTime
 { get; set; }
      [JsonProperty("operateUser")]
public 				string

             operateUser
 { get; set; }
	}
}
