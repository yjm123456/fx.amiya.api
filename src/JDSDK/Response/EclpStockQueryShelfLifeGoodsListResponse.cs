using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpStockQueryShelfLifeGoodsListResponse:JdResponse{
      [JsonProperty("pageableResult")]
public 				PageableResult

             pageableResult
 { get; set; }
	}
}
