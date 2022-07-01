using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JwPurchaseOrderOrderDetailResponse:JdResponse{
      [JsonProperty("orderdetail_result")]
public 				OrderDetailResponse

                                                                                     orderdetailResult
 { get; set; }
	}
}
