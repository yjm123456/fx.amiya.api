using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class MarketDbpCartCartDataReadServiceGetCarSkuCountResponse:JdResponse{
      [JsonProperty("skuCount")]
public 				long

             skuCount
 { get; set; }
	}
}
