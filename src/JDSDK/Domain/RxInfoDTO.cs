using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class RxInfoDTO:JdObject{
      [JsonProperty("patientName")]
public 				string

             patientName
 { get; set; }
      [JsonProperty("phone")]
public 				string

             phone
 { get; set; }
      [JsonProperty("sex")]
public 				int

             sex
 { get; set; }
      [JsonProperty("birthday")]
public 				DateTime

             birthday
 { get; set; }
      [JsonProperty("age")]
public 				int

             age
 { get; set; }
      [JsonProperty("rxPic")]
public 				string

             rxPic
 { get; set; }
      [JsonProperty("rxPicList")]
public 				List<string>

             rxPicList
 { get; set; }
      [JsonProperty("rxDepartment")]
public 				string

             rxDepartment
 { get; set; }
	}
}
