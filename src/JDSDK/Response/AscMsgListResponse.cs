using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AscMsgListResponse:JdResponse{
      [JsonProperty("result")]
public 				Result

             result
 { get; set; }
	}
}
