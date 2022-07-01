using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class QuerySalerInfoResponse:JdResponse{
      [JsonProperty("querysalerinfo_result")]
public 				Result

                                                                                     querysalerinfoResult
 { get; set; }
	}
}
