using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class MedicineDsOrderAuditCancelOrderResponse:JdResponse{
      [JsonProperty("apiResult")]
public 				AuditCancelOrderResult

             apiResult
 { get; set; }
	}
}
