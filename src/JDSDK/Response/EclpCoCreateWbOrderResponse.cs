using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpCoCreateWbOrderResponse:JdResponse{
      [JsonProperty("CoCreateLwbResult_result")]
public 				CoCreateLwbResultForCreateWbOrder

                                                                                     coCreateLwbResultResult
 { get; set; }
	}
}
