using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class YunpeiBillStatusQueryResponse:JdResponse{
      [JsonProperty("bill_status_result")]
public 				Result

                                                                                                                     billStatusResult
 { get; set; }
	}
}
