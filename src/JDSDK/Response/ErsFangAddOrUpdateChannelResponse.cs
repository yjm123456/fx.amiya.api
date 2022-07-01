using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ErsFangAddOrUpdateChannelResponse:JdResponse{
      [JsonProperty("addorupdatechannel_result")]
public 				BooleanResult

                                                                                     addorupdatechannelResult
 { get; set; }
	}
}
