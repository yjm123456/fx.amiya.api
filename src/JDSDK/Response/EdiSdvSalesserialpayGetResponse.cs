using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiSdvSalesserialpayGetResponse:JdResponse{
      [JsonProperty("salesOutWarehouseResultDto")]
public 				JosSalesOutWarehouseResultDto

             salesOutWarehouseResultDto
 { get; set; }
	}
}
