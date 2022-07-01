using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SellerPromotionGetResponse:JdResponse{
      [JsonProperty("promotion_v_o")]
public 				PromotionVO

                                                                                                                     promotionVO
 { get; set; }
	}
}
