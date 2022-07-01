using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpGoodsQueryGoodsSerialResponse:JdResponse{
      [JsonProperty("goodsSerialList")]
public 				List<string>

             goodsSerialList
 { get; set; }
	}
}
