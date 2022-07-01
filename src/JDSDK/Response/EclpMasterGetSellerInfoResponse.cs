using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpMasterGetSellerInfoResponse:JdResponse{
      [JsonProperty("getsellerinfo_result")]
public 				SellerInfoResponse

                                                                                     getsellerinfoResult
 { get; set; }
	}
}
