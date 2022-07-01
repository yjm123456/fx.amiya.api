using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EclpOrderQueryOrderCartonBySoNoResponse:JdResponse{
      [JsonProperty("result")]
public 				OrderDTO

             result
 { get; set; }
	}
}
