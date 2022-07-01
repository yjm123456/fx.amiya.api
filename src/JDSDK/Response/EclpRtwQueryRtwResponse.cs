using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpRtwQueryRtwResponse:JdResponse{
      [JsonProperty("queryrtw_result")]
public 				List<string>

                                                                                     queryrtwResult
 { get; set; }
	}
}
