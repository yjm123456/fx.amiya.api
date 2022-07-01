using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VssPromotionGetunitpromodetailResponse:JdResponse{
      [JsonProperty("promo_detail_result_dto")]
public 				UnitPromoDetailResultDto

                                                                                                                                                     promoDetailResultDto
 { get; set; }
	}
}
