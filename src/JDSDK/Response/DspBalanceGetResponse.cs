using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspBalanceGetResponse:JdResponse{
      [JsonProperty("getaccountbalance_result")]
public 				DspResult

                                                                                     getaccountbalanceResult
 { get; set; }
	}
}
