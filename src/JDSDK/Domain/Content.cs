using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class Content:JdObject{
      [JsonProperty("Slaveimageurl")]
public 				string

             Slaveimageurl
 { get; set; }
	}
}
