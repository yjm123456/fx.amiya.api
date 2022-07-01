using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQueryDeptResponse:JdResponse{
      [JsonProperty("querydept_result")]
public 				List<string>

                                                                                     querydeptResult
 { get; set; }
	}
}
