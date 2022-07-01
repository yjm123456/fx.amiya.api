using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderEquatorOrderCustomsResponse:JdResponse{
      [JsonProperty("equatorOrderCustoms_result")]
public 				Result

                                                                                     equatorOrderCustomsResult
 { get; set; }
	}
}
