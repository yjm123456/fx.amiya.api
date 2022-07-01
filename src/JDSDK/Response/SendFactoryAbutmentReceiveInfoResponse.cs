using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SendFactoryAbutmentReceiveInfoResponse:JdResponse{
      [JsonProperty("sendfactoryabutmentreceiveinfo_result")]
public 				AbutmentOrderResultInfo

                                                                                     sendfactoryabutmentreceiveinfoResult
 { get; set; }
	}
}
