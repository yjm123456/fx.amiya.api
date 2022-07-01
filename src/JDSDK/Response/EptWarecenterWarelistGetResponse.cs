using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EptWarecenterWarelistGetResponse:JdResponse{
      [JsonProperty("querywarelist_result")]
public 				WareQueryResult

                                                                                     querywarelistResult
 { get; set; }
	}
}
