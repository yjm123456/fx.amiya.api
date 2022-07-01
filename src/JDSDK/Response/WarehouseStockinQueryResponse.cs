using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class WarehouseStockinQueryResponse:JdResponse{
      [JsonProperty("vcInStockResultJosDto")]
public 				VcInStockResultJosDto

             vcInStockResultJosDto
 { get; set; }
	}
}
