using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcHtProductReportListResponse:JdResponse{
      [JsonProperty("getproductreportlist_result")]
public 				DspResult

                                                                                     getproductreportlistResult
 { get; set; }
	}
}
