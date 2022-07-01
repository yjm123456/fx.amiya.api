using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class DCStoreDto:JdObject{
      [JsonProperty("dcid")]
public 				int

             dcid
 { get; set; }
      [JsonProperty("sid")]
public 				int

             sid
 { get; set; }
	}
}
