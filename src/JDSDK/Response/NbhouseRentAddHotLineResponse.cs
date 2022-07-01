using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NbhouseRentAddHotLineResponse:JdResponse{
      [JsonProperty("addhotlinesaas_result")]
public 				RentHotLineSassResult

                                                                                     addhotlinesaasResult
 { get; set; }
	}
}
