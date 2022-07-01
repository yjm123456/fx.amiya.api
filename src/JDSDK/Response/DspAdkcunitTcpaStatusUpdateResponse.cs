using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspAdkcunitTcpaStatusUpdateResponse:JdResponse{
      [JsonProperty("tcpaStatusUpdateResult")]
public 				DspResult

             tcpaStatusUpdateResult
 { get; set; }
	}
}
