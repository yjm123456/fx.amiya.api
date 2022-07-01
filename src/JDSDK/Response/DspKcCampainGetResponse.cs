using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcCampainGetResponse:JdResponse{
      [JsonProperty("findcampaignbyid_result")]
public 				DspResult

                                                                                     findcampaignbyidResult
 { get; set; }
	}
}
