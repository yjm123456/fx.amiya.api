using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class YipOrderGetOrderCustomeInfosResponse:JdResponse{
      [JsonProperty("dataResult")]
public 				DataResult

             dataResult
 { get; set; }
	}
}
