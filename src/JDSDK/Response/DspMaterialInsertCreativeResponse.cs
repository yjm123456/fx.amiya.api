using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspMaterialInsertCreativeResponse:JdResponse{
      [JsonProperty("insertCreative_result")]
public 				DspResult

                                                                                     insertCreativeResult
 { get; set; }
	}
}
