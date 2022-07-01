using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class JosDVASItemModel:JdObject{
      [JsonProperty("serviceName")]
public 				string

             serviceName
 { get; set; }
      [JsonProperty("serviceCode")]
public 				string

             serviceCode
 { get; set; }
      [JsonProperty("serviceStatus")]
public 				byte

             serviceStatus
 { get; set; }
	}
}
