using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QueryJDPriceResponse:JdResponse{
      [JsonProperty("querynewproductprice_result")]
public 				PriceProductVo

                                                                                     querynewproductpriceResult
 { get; set; }
	}
}
