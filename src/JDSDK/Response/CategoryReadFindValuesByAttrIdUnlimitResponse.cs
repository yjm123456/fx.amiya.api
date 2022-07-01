using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CategoryReadFindValuesByAttrIdUnlimitResponse:JdResponse{
      [JsonProperty("findvaluesbyattridunlimit_result")]
public 				List<string>

                                                                                     findvaluesbyattridunlimitResult
 { get; set; }
	}
}
