using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class FactoryPurchaseQueryVPResponse:JdResponse{
      [JsonProperty("queryvp_result")]
public 				StateResult

                                                                                     queryvpResult
 { get; set; }
	}
}
