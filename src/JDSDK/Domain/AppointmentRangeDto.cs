using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AppointmentRangeDto:JdObject{
      [JsonProperty("minAppointmentTime")]
public 				string

             minAppointmentTime
 { get; set; }
      [JsonProperty("maxAppointmentTime")]
public 				string

             maxAppointmentTime
 { get; set; }
	}
}
