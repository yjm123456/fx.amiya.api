using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class TwoorderqueryResponse:JdResponse{
      [JsonProperty("twoorderquery_result")]
public 				ResultVO

                                                                                     twoorderqueryResult
 { get; set; }
	}
}
