using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class WareChangeWithApplyDTO:JdObject{
      [JsonProperty("changeWareSku")]
public 				long

             changeWareSku
 { get; set; }
      [JsonProperty("changeWareName")]
public 				string

             changeWareName
 { get; set; }
      [JsonProperty("changeWarePrice")]
public 					string

             changeWarePrice
 { get; set; }
	}
}
