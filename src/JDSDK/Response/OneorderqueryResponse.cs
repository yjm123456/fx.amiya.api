using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class OneorderqueryResponse:JdResponse{
      [JsonProperty("oneorderquery_result")]
public 				ResultVO

                                                                                     oneorderqueryResult
 { get; set; }
	}
}
