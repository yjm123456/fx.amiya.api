using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdunitStatusUpdateResponse:JdResponse{
      [JsonProperty("updatastatus_result")]
public 				DspResult

                                                                                     updatastatusResult
 { get; set; }
	}
}
