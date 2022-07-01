using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpStockQueryVmiShopStockResponse:JdResponse{
      [JsonProperty("queryvmishopstock_result")]
public 				VmiShopStockResponse

                                                                                     queryvmishopstockResult
 { get; set; }
	}
}
