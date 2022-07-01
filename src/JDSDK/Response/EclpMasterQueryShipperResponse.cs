using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQueryShipperResponse:JdResponse{
      [JsonProperty("queryshipper_result")]
public 				List<string>

                                                                                     queryshipperResult
 { get; set; }
	}
}
