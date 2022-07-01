using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class NewhouseSynHouseSpuInfoResponse:JdResponse{
      [JsonProperty("synhousespuinfo_result")]
public 				HouseJosSpuResponse

                                                                                     synhousespuinfoResult
 { get; set; }
	}
}
