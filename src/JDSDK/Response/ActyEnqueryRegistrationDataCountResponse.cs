using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ActyEnqueryRegistrationDataCountResponse:JdResponse{
      [JsonProperty("queryregistrationdatacount_result")]
public 				ActyResult

                                                                                     queryregistrationdatacountResult
 { get; set; }
	}
}
