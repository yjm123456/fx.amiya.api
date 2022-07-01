using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
															using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImgzoneImageQueryAllResponse:JdResponse{
      [JsonProperty("total_num")]
public 				int

                                                                                     totalNum
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
      [JsonProperty("return_code")]
public 				string

                                                                                     returnCode
 { get; set; }
      [JsonProperty("scroll_id")]
public 				string

                                                                                     scrollId
 { get; set; }
      [JsonProperty("result")]
public 				List<string>

             result
 { get; set; }
	}
}
