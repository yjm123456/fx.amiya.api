using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class EptVenderCategoryGetResponse:JdResponse{
      [JsonProperty("getvendercategory_result")]
public 				VenderInfoResult

                                                                                     getvendercategoryResult
 { get; set; }
	}
}
