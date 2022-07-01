using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcCampainAddResponse:JdResponse{
      [JsonProperty("addcampain_result")]
public 				DspResult

                                                                                     addcampainResult
 { get; set; }
	}
}
