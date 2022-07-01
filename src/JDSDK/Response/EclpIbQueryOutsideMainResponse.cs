using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpIbQueryOutsideMainResponse:JdResponse{
      [JsonProperty("queryOutsideMainResult")]
public 				QueryOutsideMainResult4Isv

             queryOutsideMainResult
 { get; set; }
	}
}
