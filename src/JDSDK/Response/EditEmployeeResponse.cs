using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EditEmployeeResponse:JdResponse{
      [JsonProperty("resultMessage")]
public 				ResultMessage

             resultMessage
 { get; set; }
	}
}
