using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SamOrderInfoQuerynewResponse:JdResponse{
      [JsonProperty("queryorderinfo_result")]
public 				Result

                                                                                     queryorderinfoResult
 { get; set; }
	}
}
