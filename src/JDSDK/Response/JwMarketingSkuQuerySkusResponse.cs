using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwMarketingSkuQuerySkusResponse:JdResponse{
      [JsonProperty("queryskus_result")]
public 				SkuResponse

                                                                                     queryskusResult
 { get; set; }
	}
}
