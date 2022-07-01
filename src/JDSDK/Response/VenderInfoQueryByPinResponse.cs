using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VenderInfoQueryByPinResponse:JdResponse{
      [JsonProperty("vender_info_result")]
public 				VenderInfoResult

                                                                                                                     venderInfoResult
 { get; set; }
	}
}
