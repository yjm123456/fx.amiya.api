using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DentistryAppointWriteOffResponse:JdResponse{
      [JsonProperty("returnType")]
public 				JsfResult

             returnType
 { get; set; }
	}
}
