using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpFeeQueryFeeDetailWithPageResponse:JdResponse{
      [JsonProperty("querystock_withPage_result")]
public 				PageableResult

                                                                                                                     querystockWithPageResult
 { get; set; }
	}
}
