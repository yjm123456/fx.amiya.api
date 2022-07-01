using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class PickUpResultDTO:JdObject{
      [JsonProperty("code")]
public 				int

             code
 { get; set; }
      [JsonProperty("messsage")]
public 				string

             messsage
 { get; set; }
      [JsonProperty("pickUpCode")]
public 				string

             pickUpCode
 { get; set; }
      [JsonProperty("upToLowGrade")]
public 				bool

             upToLowGrade
 { get; set; }
	}
}
