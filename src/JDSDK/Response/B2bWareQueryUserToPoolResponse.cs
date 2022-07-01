using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class B2bWareQueryUserToPoolResponse:JdResponse{
      [JsonProperty("returnType")]
public 				SdkPageResult

             returnType
 { get; set; }
	}
}
