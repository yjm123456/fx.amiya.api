using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpStockQueryStockResponse:JdResponse{
      [JsonProperty("querystock_result")]
public 				List<string>

                                                                                     querystockResult
 { get; set; }
	}
}
