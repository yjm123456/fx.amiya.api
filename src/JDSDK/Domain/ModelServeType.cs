using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ModelServeType:JdObject{
      [JsonProperty("name")]
public 				string

             name
 { get; set; }
	}
}
