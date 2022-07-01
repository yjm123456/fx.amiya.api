using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VcItemCategoriesFindResponse:JdResponse{
      [JsonProperty("jos_result_dto")]
public 				JosCategoryDto

                                                                                                                     josResultDto
 { get; set; }
	}
}
