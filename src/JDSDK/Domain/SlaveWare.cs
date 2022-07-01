using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class SlaveWare:JdObject{
      [JsonProperty("SlaveContent")]
public 				Content

             SlaveContent
 { get; set; }
      [JsonProperty("Slavewareid")]
public 				string

             Slavewareid
 { get; set; }
	}
}
