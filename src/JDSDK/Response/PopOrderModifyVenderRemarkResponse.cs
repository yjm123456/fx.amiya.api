using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderModifyVenderRemarkResponse:JdResponse{
      [JsonProperty("modifyvenderremark_result")]
public 				OperatorResult

                                                                                     modifyvenderremarkResult
 { get; set; }
	}
}
