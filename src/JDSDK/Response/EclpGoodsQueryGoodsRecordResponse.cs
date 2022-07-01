using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpGoodsQueryGoodsRecordResponse:JdResponse{
      [JsonProperty("goodsRecordQueryResult")]
public 				GoodsRecordQueryResult

             goodsRecordQueryResult
 { get; set; }
	}
}
