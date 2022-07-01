using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class CategoryReadFindValuesByIdUnlimitResponse:JdResponse{
      [JsonProperty("findvaluesbyidunlimit_result")]
public 				CategoryAttrValueUnlimit

                                                                                     findvaluesbyidunlimitResult
 { get; set; }
	}
}
