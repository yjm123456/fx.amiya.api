using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpCheckstockQueryCheckStockProfitResponse:JdResponse{
      [JsonProperty("checkstockProfitList")]
public 				List<string>

             checkstockProfitList
 { get; set; }
	}
}
