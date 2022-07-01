using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ErsFangAddOrUpdateBrokerResponse:JdResponse{
      [JsonProperty("addorupdatebroker_result")]
public 				IntValueResult

                                                                                     addorupdatebrokerResult
 { get; set; }
	}
}
