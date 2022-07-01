using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcHtcampainListResponse:JdResponse{
      [JsonProperty("getcampaignlist_result")]
public 				DspResult

                                                                                     getcampaignlistResult
 { get; set; }
	}
}
