using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class TransparentImageReadFindByWareIdResponse:JdResponse{
      [JsonProperty("imageList")]
public 				List<string>

             imageList
 { get; set; }
	}
}
