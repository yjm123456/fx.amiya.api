using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderQueryOrderListResponse:JdResponse{
      [JsonProperty("queryordervmi_result")]
public 				List<string>

                                                                                     queryordervmiResult
 { get; set; }
	}
}
