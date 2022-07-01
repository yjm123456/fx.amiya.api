using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspMaterialDeleteCreativeByIdResponse:JdResponse{
      [JsonProperty("deleteCreativeById_result")]
public 				DspResult

                                                                                     deleteCreativeByIdResult
 { get; set; }
	}
}
