using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOtoChecknumberinfoGetResponse:JdResponse{
      [JsonProperty("cknumber_result")]
public 				CheckNumberResult

                                                                                     cknumberResult
 { get; set; }
	}
}
