using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class SellerCouponWriteCreateResponse:JdResponse{
      [JsonProperty("couponId")]
public 				long

             couponId
 { get; set; }
	}
}
