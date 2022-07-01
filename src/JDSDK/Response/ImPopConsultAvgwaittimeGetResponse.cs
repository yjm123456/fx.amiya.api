using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class ImPopConsultAvgwaittimeGetResponse:JdResponse{
      [JsonProperty("avgTime")]
public 				double

             avgTime
 { get; set; }
	}
}
