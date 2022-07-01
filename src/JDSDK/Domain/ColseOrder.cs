using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ColseOrder:JdObject{
      [JsonProperty("reason")]
public 				string

             reason
 { get; set; }
      [JsonProperty("orderNo")]
public 				string

             orderNo
 { get; set; }
	}
}
