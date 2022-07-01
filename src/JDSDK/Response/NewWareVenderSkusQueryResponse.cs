using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewWareVenderSkusQueryResponse:JdResponse{
      [JsonProperty("search_result")]
public 				SearchResult

                                                                                     searchResult
 { get; set; }
	}
}
