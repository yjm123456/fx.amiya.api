using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
							namespace Jd.Api.Response
{

public class ClubPopCommentreplySaveResponse:JdResponse{
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("resultMsg")]
public 				string

             resultMsg
 { get; set; }
	}
}
