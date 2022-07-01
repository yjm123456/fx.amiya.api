using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpSerialQueryInStockSIDBySkuResponse:JdResponse{
      [JsonProperty("queryinstocksidbysku_result")]
public 				QueryInStockSIDBySkuResponse

                                                                                     queryinstocksidbyskuResult
 { get; set; }
	}
}
