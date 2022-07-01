using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspMaterialAddMaterialResponse:JdResponse{
      [JsonProperty("addMaterial_result")]
public 				DspResult

                                                                                     addMaterialResult
 { get; set; }
	}
}
