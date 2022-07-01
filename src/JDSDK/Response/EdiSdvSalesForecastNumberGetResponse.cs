using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class EdiSdvSalesForecastNumberGetResponse:JdResponse{
      [JsonProperty("salesForecastNumber")]
public 				int

             salesForecastNumber
 { get; set; }
	}
}
