using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcEffectLocationReportListResponse:JdResponse{
      [JsonProperty("getlocationeffectreportlist_result")]
public 				DspResultVO

                                                                                     getlocationeffectreportlistResult
 { get; set; }
	}
}
