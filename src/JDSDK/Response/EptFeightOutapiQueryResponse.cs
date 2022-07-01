using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EptFeightOutapiQueryResponse:JdResponse{
      [JsonProperty("getshopfreighttemplatelist_result")]
public 				List<string>

                                                                                     getshopfreighttemplatelistResult
 { get; set; }
	}
}
