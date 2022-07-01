using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderQueryOrderStatusResponse:JdResponse{
      [JsonProperty("queryorderstatus_result")]
public 				OrderDefaultResultStatus

                                                                                     queryorderstatusResult
 { get; set; }
	}
}
