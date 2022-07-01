using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class HouseWishplatVO:JdObject{
      [JsonProperty("userPhone")]
public 				string

             userPhone
 { get; set; }
      [JsonProperty("describe")]
public 				string

             describe
 { get; set; }
      [JsonProperty("activityName")]
public 				string

             activityName
 { get; set; }
      [JsonProperty("venderName")]
public 				string

             venderName
 { get; set; }
      [JsonProperty("activityCreateTime")]
public 				DateTime

             activityCreateTime
 { get; set; }
	}
}
