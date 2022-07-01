using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PickupDto:JdObject{
      [JsonProperty("againWeight")]
public 				double

             againWeight
 { get; set; }
	}
}
