using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class GetProductLimitResponse:JdResponse{
      [JsonProperty("getproductlimit_result")]
public 				Result

                                                                                     getproductlimitResult
 { get; set; }
	}
}
