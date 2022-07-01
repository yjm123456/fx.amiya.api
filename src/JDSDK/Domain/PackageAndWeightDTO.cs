using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PackageAndWeightDTO:JdObject{
      [JsonProperty("deliveryId")]
public 				string

             deliveryId
 { get; set; }
      [JsonProperty("weight")]
public 				double

             weight
 { get; set; }
      [JsonProperty("goodNumber")]
public 				int

             goodNumber
 { get; set; }
	}
}
