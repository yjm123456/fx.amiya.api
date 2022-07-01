using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QuerySymbolApprovalListResponse:JdResponse{
      [JsonProperty("response")]
public 				BdsRpcResponse

             response
 { get; set; }
	}
}
