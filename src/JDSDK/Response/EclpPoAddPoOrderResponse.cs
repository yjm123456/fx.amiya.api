using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class EclpPoAddPoOrderResponse:JdResponse{
      [JsonProperty("poOrderNo")]
public 				string

             poOrderNo
 { get; set; }
	}
}
