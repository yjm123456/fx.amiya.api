using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ArrayList:JdObject{
      [JsonProperty("crowdId")]
public 				long

             crowdId
 { get; set; }
	}
}
