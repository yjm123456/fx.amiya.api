using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class UeOrderFinishBizProgressResponse:JdResponse{
      [JsonProperty("returnType")]
public 				ResultInfo

             returnType
 { get; set; }
	}
}
