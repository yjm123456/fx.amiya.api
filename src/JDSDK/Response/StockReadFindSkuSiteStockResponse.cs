using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class StockReadFindSkuSiteStockResponse:JdResponse{
      [JsonProperty("app_params")]
public 				SkuSiteStock

                                                                                     appParams
 { get; set; }
	}
}
