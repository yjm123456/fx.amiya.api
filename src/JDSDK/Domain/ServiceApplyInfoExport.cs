using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ServiceApplyInfoExport:JdObject{
      [JsonProperty("expectPickwareType")]
public 				int

             expectPickwareType
 { get; set; }
      [JsonProperty("customerExpect")]
public 				int

             customerExpect
 { get; set; }
	}
}
