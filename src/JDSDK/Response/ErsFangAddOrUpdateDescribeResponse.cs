using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ErsFangAddOrUpdateDescribeResponse:JdResponse{
      [JsonProperty("addplotrate_result")]
public 				Result

                                                                                     addplotrateResult
 { get; set; }
	}
}
