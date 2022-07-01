using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SvcBookingListResponse:JdResponse{
      [JsonProperty("getsvcbookingverification_result")]
public 				SvcResult

                                                                                     getsvcbookingverificationResult
 { get; set; }
	}
}
