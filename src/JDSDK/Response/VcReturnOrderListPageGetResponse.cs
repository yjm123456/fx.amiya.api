using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VcReturnOrderListPageGetResponse:JdResponse{
      [JsonProperty("roResultDto")]
public 				RoResultDto

             roResultDto
 { get; set; }
	}
}
