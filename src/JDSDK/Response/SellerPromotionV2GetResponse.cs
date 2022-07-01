using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SellerPromotionV2GetResponse:JdResponse{
      [JsonProperty("jos_promotion")]
public 				JosPromotion

                                                                                     josPromotion
 { get; set; }
	}
}
