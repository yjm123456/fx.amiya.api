using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AppointmentInfoExport:JdObject{
      [JsonProperty("appointDateBegin")]
public 				DateTime

             appointDateBegin
 { get; set; }
      [JsonProperty("appointDateEnd")]
public 				DateTime

             appointDateEnd
 { get; set; }
      [JsonProperty("appointDateStr")]
public 				string

             appointDateStr
 { get; set; }
      [JsonProperty("appointDateType")]
public 				int

             appointDateType
 { get; set; }
      [JsonProperty("reserveDate")]
public 				DateTime

             reserveDate
 { get; set; }
      [JsonProperty("sendPay")]
public 				string

             sendPay
 { get; set; }
	}
}
