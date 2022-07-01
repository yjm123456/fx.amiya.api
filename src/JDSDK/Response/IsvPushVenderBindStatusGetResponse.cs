using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class IsvPushVenderBindStatusGetResponse:JdResponse{
      [JsonProperty("getvenderbindstatus_result")]
public 				PublicResult

                                                                                     getvenderbindstatusResult
 { get; set; }
	}
}
