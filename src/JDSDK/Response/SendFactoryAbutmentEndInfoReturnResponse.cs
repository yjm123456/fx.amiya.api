using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SendFactoryAbutmentEndInfoReturnResponse:JdResponse{
      [JsonProperty("sendfactoryabutmentendinforeturn_result")]
public 				AbutmentOrderResultInfo

                                                                                     sendfactoryabutmentendinforeturnResult
 { get; set; }
	}
}
