using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class KuaicheZnSpacePageByTypeSearchResponse:JdResponse{
      [JsonProperty("space_page_info_list")]
public 				List<string>

                                                                                                                                                     spacePageInfoList
 { get; set; }
	}
}
