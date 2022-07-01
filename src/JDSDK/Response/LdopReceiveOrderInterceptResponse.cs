using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LdopReceiveOrderInterceptResponse:JdResponse{
      [JsonProperty("resultInfo")]
public 				OrderInfoOperateResponse

             resultInfo
 { get; set; }
	}
}
