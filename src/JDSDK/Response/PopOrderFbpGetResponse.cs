using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderFbpGetResponse:JdResponse{
      [JsonProperty("searchfbporderbyid_result")]
public 				OrderDetailInfo

                                                                                     searchfbporderbyidResult
 { get; set; }
	}
}
