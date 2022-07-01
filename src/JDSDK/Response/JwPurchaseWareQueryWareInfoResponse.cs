using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwPurchaseWareQueryWareInfoResponse:JdResponse{
      [JsonProperty("querywareinfo_result")]
public 				WareDetailResponse

                                                                                     querywareinfoResult
 { get; set; }
	}
}
