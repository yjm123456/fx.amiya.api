using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpStockQueryWarehouseStockOrderFlowByGroupResponse:JdResponse{
      [JsonProperty("resultList")]
public 				List<string>

             resultList
 { get; set; }
	}
}
