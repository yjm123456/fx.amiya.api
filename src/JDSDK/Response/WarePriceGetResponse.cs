using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class WarePriceGetResponse:JdResponse{
      [JsonProperty("price_changes")]
public 				List<string>

                                                                                     priceChanges
 { get; set; }
	}
}
