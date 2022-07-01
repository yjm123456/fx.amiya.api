using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class LogisticsCarriersListResponse:JdResponse{
      [JsonProperty("carriers_details")]
public 				List          <CarriersDetail>

                                                                                     carriersDetails
 { get; set; }
	}
}
