using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SkuReadSearchSkuListResponse:JdResponse{
      [JsonProperty("page")]
public 				Page

             page
 { get; set; }
	}
}
