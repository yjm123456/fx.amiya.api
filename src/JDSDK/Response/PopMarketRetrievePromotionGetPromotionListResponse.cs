using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopMarketRetrievePromotionGetPromotionListResponse:JdResponse{
      [JsonProperty("promotionList")]
public 				List<string>

             promotionList
 { get; set; }
	}
}
