using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VcGetpurchaseorderlistResponse:JdResponse{
      [JsonProperty("jos_order_result_dto")]
public 				JOSOrderResultDto

                                                                                                                                                     josOrderResultDto
 { get; set; }
	}
}
