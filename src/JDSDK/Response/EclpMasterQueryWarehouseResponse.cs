using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQueryWarehouseResponse:JdResponse{
      [JsonProperty("querywarehouse_result")]
public 				List<string>

                                                                                     querywarehouseResult
 { get; set; }
	}
}
