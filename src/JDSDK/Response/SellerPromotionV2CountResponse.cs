using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class SellerPromotionV2CountResponse:JdResponse{
      [JsonProperty("promotion_count")]
public 				int

                                                                                     promotionCount
 { get; set; }
	}
}
