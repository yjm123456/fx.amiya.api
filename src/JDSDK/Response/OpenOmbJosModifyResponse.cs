using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class OpenOmbJosModifyResponse:JdResponse{
      [JsonProperty("response")]
public 				BaseResponse

             response
 { get; set; }
	}
}
