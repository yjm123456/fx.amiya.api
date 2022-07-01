using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PushinformationdataResponse:JdResponse{
      [JsonProperty("pushinformationdata_result")]
public 				ResultVO

                                                                                     pushinformationdataResult
 { get; set; }
	}
}
