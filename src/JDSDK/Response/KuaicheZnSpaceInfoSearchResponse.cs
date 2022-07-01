using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class KuaicheZnSpaceInfoSearchResponse:JdResponse{
      [JsonProperty("space_info_list")]
public 				List<string>

                                                                                                                     spaceInfoList
 { get; set; }
	}
}
