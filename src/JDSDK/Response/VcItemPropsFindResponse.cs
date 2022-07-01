using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VcItemPropsFindResponse:JdResponse{
      [JsonProperty("jos_result_dto")]
public 				JosPropGroupDto

                                                                                                                     josResultDto
 { get; set; }
	}
}
