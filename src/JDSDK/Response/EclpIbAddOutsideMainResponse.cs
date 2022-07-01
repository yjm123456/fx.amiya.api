using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class EclpIbAddOutsideMainResponse:JdResponse{
      [JsonProperty("outsideMainNo")]
public 				string

             outsideMainNo
 { get; set; }
	}
}
