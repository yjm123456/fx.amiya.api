using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsReturnorderQueryResponse:JdResponse{
      [JsonProperty("response_return_order")]
public 				ResponseReturnOrder

                                                                                                                     responseReturnOrder
 { get; set; }
	}
}
