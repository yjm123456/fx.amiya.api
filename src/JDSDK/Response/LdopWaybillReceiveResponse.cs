using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LdopWaybillReceiveResponse:JdResponse{
      [JsonProperty("receiveorderinfo_result")]
public 				WaybillResultInfoDTO

                                                                                     receiveorderinfoResult
 { get; set; }
	}
}
