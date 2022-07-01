using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class PmxPricesMgetsResponse:JdResponse{
      [JsonProperty("skuPriceList")]
public 				List<string>

             skuPriceList
 { get; set; }
	}
}
