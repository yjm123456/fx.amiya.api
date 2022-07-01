using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class WarehouseInboundOrderQueryListResponse:JdResponse{
      [JsonProperty("vcWareHouseInResultJosDto")]
public 				VcWareHouseInResultJosDto

             vcWareHouseInResultJosDto
 { get; set; }
	}
}
