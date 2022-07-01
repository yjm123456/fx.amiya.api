using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewhouseBindingSpuBrokerResponse:JdResponse{
      [JsonProperty("bindingspubroker_result")]
public 				HouseJosCommonResponse

                                                                                     bindingspubrokerResult
 { get; set; }
	}
}
