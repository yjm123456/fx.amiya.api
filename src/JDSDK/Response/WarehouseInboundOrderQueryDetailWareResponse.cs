using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class WarehouseInboundOrderQueryDetailWareResponse:JdResponse{
      [JsonProperty("vcWareHouseInDetailResultJosDto")]
public 				VcWareHouseInDetailResultJosDto

             vcWareHouseInDetailResultJosDto
 { get; set; }
	}
}
