using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class FeimaQueryShopPageResponse:JdResponse{
      [JsonProperty("queryshoppage_result")]
public 				Result

                                                                                     queryshoppageResult
 { get; set; }
	}
}
