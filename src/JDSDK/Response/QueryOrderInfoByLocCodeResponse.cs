using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QueryOrderInfoByLocCodeResponse:JdResponse{
      [JsonProperty("queryorderinfobycouponcode_result")]
public 				ResultBean

                                                                                     queryorderinfobycouponcodeResult
 { get; set; }
	}
}
