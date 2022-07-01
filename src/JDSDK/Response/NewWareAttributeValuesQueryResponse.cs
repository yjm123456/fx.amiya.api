using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewWareAttributeValuesQueryResponse:JdResponse{
      [JsonProperty("resultset")]
public 				List<string>

             resultset
 { get; set; }
	}
}
