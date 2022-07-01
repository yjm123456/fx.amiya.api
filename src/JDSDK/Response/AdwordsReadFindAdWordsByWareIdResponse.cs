using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AdwordsReadFindAdWordsByWareIdResponse:JdResponse{
      [JsonProperty("adWords")]
public 				AdWords

             adWords
 { get; set; }
	}
}
