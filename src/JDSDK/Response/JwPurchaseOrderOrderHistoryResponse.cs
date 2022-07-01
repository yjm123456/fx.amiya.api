using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwPurchaseOrderOrderHistoryResponse:JdResponse{
      [JsonProperty("orderhistory_result")]
public 				OrderHistoryResponse

                                                                                     orderhistoryResult
 { get; set; }
	}
}
