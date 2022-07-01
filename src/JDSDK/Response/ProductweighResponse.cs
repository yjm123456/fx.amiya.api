using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ProductweighResponse:JdResponse{
      [JsonProperty("productweigh_result")]
public 				ResultVO

                                                                                     productweighResult
 { get; set; }
	}
}
