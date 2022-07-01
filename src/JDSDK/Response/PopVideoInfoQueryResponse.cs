using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopVideoInfoQueryResponse:JdResponse{
      [JsonProperty("page_result")]
public 				JOSPageResult

                                                                                     pageResult
 { get; set; }
	}
}
