using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ArealimitReadFindAreaLimitsByWareIdResponse:JdResponse{
      [JsonProperty("wareAreaLimitList")]
public 				List<string>

             wareAreaLimitList
 { get; set; }
	}
}
