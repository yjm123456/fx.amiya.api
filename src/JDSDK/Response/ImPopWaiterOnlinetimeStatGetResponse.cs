using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImPopWaiterOnlinetimeStatGetResponse:JdResponse{
      [JsonProperty("WaiterDailyStat")]
public 				List<string>

             WaiterDailyStat
 { get; set; }
	}
}
