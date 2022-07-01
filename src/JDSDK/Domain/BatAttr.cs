using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BatAttr:JdObject{
      [JsonProperty("batchKey")]
public 				string

             batchKey
 { get; set; }
      [JsonProperty("batchValue")]
public 				string

             batchValue
 { get; set; }
	}
}
