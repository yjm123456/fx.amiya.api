using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EdiSdvCustomerOrderSearchResponse:JdResponse{
      [JsonProperty("customerOrders")]
public 				List<string>

             customerOrders
 { get; set; }
	}
}
