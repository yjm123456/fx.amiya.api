using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspMaterialQueryMaterialByIdResponse:JdResponse{
      [JsonProperty("queryMaterialById_result")]
public 				DspResult

                                                                                     queryMaterialByIdResult
 { get; set; }
	}
}
