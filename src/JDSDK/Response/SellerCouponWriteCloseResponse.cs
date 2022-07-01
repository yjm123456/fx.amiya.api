using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class SellerCouponWriteCloseResponse:JdResponse{
      [JsonProperty("close_result")]
public 					bool

                                                                                     closeResult
 { get; set; }
	}
}
