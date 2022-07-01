using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
										namespace Jd.Api.Response
{

public class ImgzoneCategoryAddResponse:JdResponse{
      [JsonProperty("return_code")]
public 				int

                                                                                     returnCode
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
      [JsonProperty("cate_id")]
public 				long

                                                                                     cateId
 { get; set; }
	}
}
