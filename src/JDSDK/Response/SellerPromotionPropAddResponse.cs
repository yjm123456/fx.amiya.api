using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class SellerPromotionPropAddResponse:JdResponse{
      [JsonProperty("ids")]
public 				List<string>

             ids
 { get; set; }
	}
}
