using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
									using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImgzoneCategoryQueryResponse:JdResponse{
      [JsonProperty("return_code")]
public 				int

                                                                                     returnCode
 { get; set; }
      [JsonProperty("desc1")]
public 				string

             desc1
 { get; set; }
      [JsonProperty("cateList")]
public 				List<string>

             cateList
 { get; set; }
	}
}
