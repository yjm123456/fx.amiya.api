using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
				namespace Jd.Api.Response
{

public class PopVideoInfosDeleteResponse:JdResponse{
      [JsonProperty("del_success_ids")]
public 				List<string>

                                                                                                                     delSuccessIds
 { get; set; }
	}
}
