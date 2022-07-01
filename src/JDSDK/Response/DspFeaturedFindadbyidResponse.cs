using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspFeaturedFindadbyidResponse:JdResponse{
      [JsonProperty("findadbyid_result")]
public 				DspResult

                                                                                     findadbyidResult
 { get; set; }
	}
}
