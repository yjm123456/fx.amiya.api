using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
									using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class JcloudWmsStockQuerySumResponse:JdResponse{
      [JsonProperty("resultCode")]
public 				string

             resultCode
 { get; set; }
      [JsonProperty("message")]
public 				string

             message
 { get; set; }
      [JsonProperty("content")]
public 				List<string>

             content
 { get; set; }
	}
}
