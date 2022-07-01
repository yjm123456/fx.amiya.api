using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RealEstateHotlineLandingVO:JdObject{
      [JsonProperty("phoneLanding")]
public 				string

             phoneLanding
 { get; set; }
      [JsonProperty("type")]
public 				int

             type
 { get; set; }
	}
}
