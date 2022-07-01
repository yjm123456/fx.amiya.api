using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class NewWareSameproductskuidsQueryResponse:JdResponse{
      [JsonProperty("result")]
public 				List<string>

             result
 { get; set; }
	}
}
