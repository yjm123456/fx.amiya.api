using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PresortWithReturnDetailResponse:JdResponse{
      [JsonProperty("presortwithreturndetail_result")]
public 				BatchOpenPresortResponseDto

                                                                                     presortwithreturndetailResult
 { get; set; }
	}
}
