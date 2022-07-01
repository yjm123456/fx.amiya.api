using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class GetUserPlusLevelQueryResponse:JdResponse{
      [JsonProperty("userPlusLevel")]
public 				string

             userPlusLevel
 { get; set; }
	}
}
