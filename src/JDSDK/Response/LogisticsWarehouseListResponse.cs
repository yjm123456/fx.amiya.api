using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsWarehouseListResponse:JdResponse{
      [JsonProperty("warehouse_details")]
public 				List<string>

                                                                                     warehouseDetails
 { get; set; }
	}
}
