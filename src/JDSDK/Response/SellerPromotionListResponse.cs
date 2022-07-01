using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
						using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SellerPromotionListResponse:JdResponse{
      [JsonProperty("total_count")]
public 				int

                                                                                     totalCount
 { get; set; }
      [JsonProperty("promotion_v_o_s")]
public 				List<string>

                                                                                                                                                     promotionVOS
 { get; set; }
	}
}
