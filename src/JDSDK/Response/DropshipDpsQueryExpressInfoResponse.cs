using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DropshipDpsQueryExpressInfoResponse:JdResponse{
      [JsonProperty("queryExpressInfoResult")]
public 				Result

             queryExpressInfoResult
 { get; set; }
	}
}
