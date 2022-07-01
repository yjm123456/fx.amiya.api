using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpStockQueryGoodsLevelChangeResponse:JdResponse{
      [JsonProperty("levelChangeResultList")]
public 				List<string>

             levelChangeResultList
 { get; set; }
	}
}
