using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class KuaicheAccountGetResponse:JdResponse{
      [JsonProperty("account")]
public 				AccountVO

             account
 { get; set; }
	}
}
