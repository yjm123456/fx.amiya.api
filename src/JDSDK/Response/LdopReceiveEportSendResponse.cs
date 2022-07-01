using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LdopReceiveEportSendResponse:JdResponse{
      [JsonProperty("receiveextenmessagetoeport_result")]
public 				EportResultInfoDTO

                                                                                     receiveextenmessagetoeportResult
 { get; set; }
	}
}
