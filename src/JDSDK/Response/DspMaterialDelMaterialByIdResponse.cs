using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspMaterialDelMaterialByIdResponse:JdResponse{
      [JsonProperty("delMaterialById_result")]
public 				DspResult

                                                                                     delMaterialByIdResult
 { get; set; }
	}
}
