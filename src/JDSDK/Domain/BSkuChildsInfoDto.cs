using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class BSkuChildsInfoDto:JdObject{
      [JsonProperty("childNum")]
public 				int

             childNum
 { get; set; }
	}
}
