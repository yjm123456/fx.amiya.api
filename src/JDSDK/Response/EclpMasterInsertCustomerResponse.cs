using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class EclpMasterInsertCustomerResponse:JdResponse{
      [JsonProperty("customerNo")]
public 				string

             customerNo
 { get; set; }
	}
}
