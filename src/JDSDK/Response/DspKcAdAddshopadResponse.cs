using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspKcAdAddshopadResponse:JdResponse{
      [JsonProperty("addshopad_result")]
public 				DspResult

                                                                                     addshopadResult
 { get; set; }
	}
}
