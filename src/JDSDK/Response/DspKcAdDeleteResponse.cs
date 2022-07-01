using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcAdDeleteResponse:JdResponse{
      [JsonProperty("delete_result")]
public 				DspResult

                                                                                     deleteResult
 { get; set; }
	}
}
