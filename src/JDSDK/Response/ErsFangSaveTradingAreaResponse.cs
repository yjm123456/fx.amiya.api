using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ErsFangSaveTradingAreaResponse:JdResponse{
      [JsonProperty("save_result")]
public 				IdResult

                                                                                     saveResult
 { get; set; }
	}
}
