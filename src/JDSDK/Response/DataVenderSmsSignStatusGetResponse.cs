using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DataVenderSmsSignStatusGetResponse:JdResponse{
      [JsonProperty("result")]
public 				StatusDataResult

             result
 { get; set; }
	}
}
