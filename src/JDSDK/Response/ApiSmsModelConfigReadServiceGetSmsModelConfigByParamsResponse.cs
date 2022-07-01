using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ApiSmsModelConfigReadServiceGetSmsModelConfigByParamsResponse:JdResponse{
      [JsonProperty("list")]
public 				List<string>

             list
 { get; set; }
	}
}
