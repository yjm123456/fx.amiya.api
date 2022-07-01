using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class EdiSdvCustomerOrderNumberGetResponse:JdResponse{
      [JsonProperty("orderNumber")]
public 				int

             orderNumber
 { get; set; }
	}
}
