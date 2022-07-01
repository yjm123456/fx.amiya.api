using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class B2bProductStockGetResponse:JdResponse{
      [JsonProperty("returnType")]
public 				ResultBase

             returnType
 { get; set; }
	}
}
