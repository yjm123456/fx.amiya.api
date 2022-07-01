using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class EclpSerialQueryRtwNosResponse:JdResponse{
      [JsonProperty("queryrtwnos_result")]
public 				List<string>

                                                                                     queryrtwnosResult
 { get; set; }
	}
}
