using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class OneorderiteminvalidResponse:JdResponse{
      [JsonProperty("oneorderiteminvalid_result")]
public 				ResultVO

                                                                                     oneorderiteminvalidResult
 { get; set; }
	}
}
