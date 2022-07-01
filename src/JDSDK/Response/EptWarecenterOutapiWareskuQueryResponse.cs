using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EptWarecenterOutapiWareskuQueryResponse:JdResponse{
      [JsonProperty("queryskuinfo_result")]
public 				WareSkuApiResponse

                                                                                     queryskuinfoResult
 { get; set; }
	}
}
