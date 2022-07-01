using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class YunpeiOrderConfirmResponse:JdResponse{
      [JsonProperty("getorderdetail_result")]
public 				Result

                                                                                     getorderdetailResult
 { get; set; }
	}
}
