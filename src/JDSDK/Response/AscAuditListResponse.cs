using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AscAuditListResponse:JdResponse{
      [JsonProperty("pageResult")]
public 				WaitAuditApplyPage

             pageResult
 { get; set; }
	}
}
