using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspMaterialQueryCreativeByParamResponse:JdResponse{
      [JsonProperty("queryCreativeByParam_result")]
public 				DspResult

                                                                                     queryCreativeByParamResult
 { get; set; }
	}
}
