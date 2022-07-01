using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VcItemSpuTemplateGetResponse:JdResponse{
      [JsonProperty("jos_result_dto")]
public 				JosSpuTemplateDto

                                                                                                                     josResultDto
 { get; set; }
	}
}
