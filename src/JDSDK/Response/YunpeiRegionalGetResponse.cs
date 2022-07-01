using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class YunpeiRegionalGetResponse:JdResponse{
      [JsonProperty("regional_result")]
public 				Result

                                                                                     regionalResult
 { get; set; }
	}
}
