using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiSdvSalesinfoGetResponse:JdResponse{
      [JsonProperty("salesInfoResultDto")]
public 				JosSalesInfoResultDto

             salesInfoResultDto
 { get; set; }
	}
}
