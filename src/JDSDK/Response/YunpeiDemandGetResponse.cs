using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class YunpeiDemandGetResponse:JdResponse{
      [JsonProperty("queryDemandDetail_result")]
public 				Result

                                                                                     queryDemandDetailResult
 { get; set; }
	}
}
