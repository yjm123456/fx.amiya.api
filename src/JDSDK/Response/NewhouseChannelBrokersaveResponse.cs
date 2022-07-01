using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewhouseChannelBrokersaveResponse:JdResponse{
      [JsonProperty("save_result")]
public 				JosResult

                                                                                     saveResult
 { get; set; }
	}
}
