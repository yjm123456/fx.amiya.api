using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class FindBusinessByVenderIdResponse:JdResponse{
      [JsonProperty("findbusinessbyvenderid_result")]
public 				BusinessInfo

                                                                                     findbusinessbyvenderidResult
 { get; set; }
	}
}
