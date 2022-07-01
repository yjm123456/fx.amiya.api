using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpStockQueryAdventGoodsStockResponse:JdResponse{
      [JsonProperty("queryadventgoodsstock_result")]
public 				AdventGoodsStockResponse

                                                                                     queryadventgoodsstockResult
 { get; set; }
	}
}
