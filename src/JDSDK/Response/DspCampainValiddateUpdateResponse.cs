using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspCampainValiddateUpdateResponse:JdResponse{
      [JsonProperty("updatevaliddate_result")]
public 				DspResult

                                                                                     updatevaliddateResult
 { get; set; }
	}
}
