using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewWareBaseproductGetResponse:JdResponse{
      [JsonProperty("listproductbase_result")]
public 				List<string>

                                                                                     listproductbaseResult
 { get; set; }
	}
}
