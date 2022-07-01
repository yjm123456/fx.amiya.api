using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopVenderCenerVenderBrandQueryResponse:JdResponse{
      [JsonProperty("brandList")]
public 				List<string>

             brandList
 { get; set; }
	}
}
