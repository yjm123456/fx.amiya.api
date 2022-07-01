using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpCheckstockQueryCheckStockLossesResponse:JdResponse{
      [JsonProperty("checkstocklossesList")]
public 				List<string>

             checkstocklossesList
 { get; set; }
	}
}
