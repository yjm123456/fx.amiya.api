using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class HealthcareAppointmentResultCallbackResponse:JdResponse{
      [JsonProperty("Result")]
public 				JsfResult

             Result
 { get; set; }
	}
}
