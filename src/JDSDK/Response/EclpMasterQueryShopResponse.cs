using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterQueryShopResponse:JdResponse{
      [JsonProperty("queryshop_result")]
public 				List<string>

                                                                                     queryshopResult
 { get; set; }
	}
}
