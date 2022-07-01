using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImageReadFindImagesByWareIdResponse:JdResponse{
      [JsonProperty("images")]
public 				List<string>

             images
 { get; set; }
	}
}
