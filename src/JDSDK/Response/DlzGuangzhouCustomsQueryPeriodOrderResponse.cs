using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DlzGuangzhouCustomsQueryPeriodOrderResponse:JdResponse{
      [JsonProperty("queryperiodorder_result")]
public 				EclpdlzServiceProviderOrderListResult

                                                                                     queryperiodorderResult
 { get; set; }
	}
}
