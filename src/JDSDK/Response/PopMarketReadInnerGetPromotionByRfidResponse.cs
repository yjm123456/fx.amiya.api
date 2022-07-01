using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopMarketReadInnerGetPromotionByRfidResponse:JdResponse{
      [JsonProperty("promotion")]
public 				Promotion

             promotion
 { get; set; }
	}
}
