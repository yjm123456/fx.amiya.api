using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResultInfo:JdObject{
      [JsonProperty("resultCode")]
public 				int

             resultCode
 { get; set; }
      [JsonProperty("errMsg")]
public 				string

             errMsg
 { get; set; }
      [JsonProperty("asmsVenderTaskQuery")]
public 				AsmsVenderTaskQuery

             asmsVenderTaskQuery
 { get; set; }
      [JsonProperty("appointmentRangeDto")]
public 				AppointmentRangeDto

             appointmentRangeDto
 { get; set; }
      [JsonProperty("asmsVenderTaskDtoForOut")]
public 				AsmsVenderTaskDtoForOut

             asmsVenderTaskDtoForOut
 { get; set; }
      [JsonProperty("quoteItemDetailList")]
public 				List<string>

             quoteItemDetailList
 { get; set; }
	}
}
