using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class GetStagepayBusinessExtInfoByCouponCodeResponse:JdResponse{
      [JsonProperty("stagepaybusinessinfo_result")]
public 				ResultBean

                                                                                     stagepaybusinessinfoResult
 { get; set; }
	}
}
