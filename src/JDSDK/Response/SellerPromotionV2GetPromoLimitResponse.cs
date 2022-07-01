using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SellerPromotionV2GetPromoLimitResponse:JdResponse{
      [JsonProperty("jos_promo_limit")]
public 				PromoLimit

                                                                                                                     josPromoLimit
 { get; set; }
	}
}
