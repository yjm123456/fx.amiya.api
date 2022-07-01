using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class WareProductsortGetResponse:JdResponse{
      [JsonProperty("product_sorts")]
public 				List<string>

                                                                                     productSorts
 { get; set; }
	}
}
