using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
						using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SellerPromotionSkuListResponse:JdResponse{
      [JsonProperty("total_count")]
public 				int

                                                                                     totalCount
 { get; set; }
      [JsonProperty("promo_sku_v_o_s")]
public 				List<string>

                                                                                                                                                                                     promoSkuVOS
 { get; set; }
	}
}
