using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQuerySpSourceResponse:JdResponse{
      [JsonProperty("queryspsource_result")]
public 				List<string>

                                                                                     queryspsourceResult
 { get; set; }
	}
}
