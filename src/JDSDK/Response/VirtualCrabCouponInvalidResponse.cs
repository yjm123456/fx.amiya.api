using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VirtualCrabCouponInvalidResponse:JdResponse{
      [JsonProperty("invalidCoupon_result")]
public 				BaseApiReturnVo

                                                                                     invalidCouponResult
 { get; set; }
	}
}
