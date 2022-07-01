using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SvcBookingVerificationInfoResponse:JdResponse{
      [JsonProperty("bookingverification_result")]
public 				SvcResult

                                                                                     bookingverificationResult
 { get; set; }
	}
}
