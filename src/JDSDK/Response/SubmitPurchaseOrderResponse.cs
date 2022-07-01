using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SubmitPurchaseOrderResponse:JdResponse{
      [JsonProperty("submitpurchaseorder_result")]
public 				Result

                                                                                     submitpurchaseorderResult
 { get; set; }
	}
}
