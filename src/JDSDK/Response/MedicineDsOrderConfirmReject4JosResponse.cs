using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class MedicineDsOrderConfirmReject4JosResponse:JdResponse{
      [JsonProperty("apiResult")]
public 				ConfirmReject4JosResult

             apiResult
 { get; set; }
	}
}
