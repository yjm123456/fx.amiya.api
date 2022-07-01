using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspMaterialQueryListByParamResponse:JdResponse{
      [JsonProperty("queryListByParam_result")]
public 				DspResult

                                                                                     queryListByParamResult
 { get; set; }
	}
}
