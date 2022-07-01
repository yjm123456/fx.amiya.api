using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ErsFangAddOrUpdatePlotResponse:JdResponse{
      [JsonProperty("addorupdateplot_result")]
public 				IntValueResult

                                                                                     addorupdateplotResult
 { get; set; }
	}
}
