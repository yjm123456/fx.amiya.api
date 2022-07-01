using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SellerPromotionV2SkuListResponse:JdResponse{
      [JsonProperty("promotion_sku_list")]
public 				List<string>

                                                                                                                     promotionSkuList
 { get; set; }
	}
}
