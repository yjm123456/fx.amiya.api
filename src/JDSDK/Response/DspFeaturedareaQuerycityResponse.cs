using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspFeaturedareaQuerycityResponse:JdResponse{
      [JsonProperty("querycity_result")]
public 				DspResult

                                                                                     querycityResult
 { get; set; }
	}
}
