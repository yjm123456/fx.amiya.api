using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class UserCategory3InfoGetResponse:JdResponse{
      [JsonProperty("userCategory3Info")]
public 				UserCategory3InfoDto

             userCategory3Info
 { get; set; }
	}
}
