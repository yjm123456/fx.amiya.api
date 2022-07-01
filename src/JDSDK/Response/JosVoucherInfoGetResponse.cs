using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JosVoucherInfoGetResponse:JdResponse{
      [JsonProperty("response")]
public 				ResponseVO

             response
 { get; set; }
	}
}
