using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SellerPromotionActivitymodeGetResponse:JdResponse{
      [JsonProperty("activity_mode")]
public 				ActivityModeVO

                                                                                     activityMode
 { get; set; }
	}
}
