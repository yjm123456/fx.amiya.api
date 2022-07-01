using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VcItemPrimaryPicAppliesFindResponse:JdResponse{
      [JsonProperty("jos_result_dto")]
public 				JosItemPicApplyDto

                                                                                                                     josResultDto
 { get; set; }
	}
}
