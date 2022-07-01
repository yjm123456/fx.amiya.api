using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
												using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImgzonePictureQueryResponse:JdResponse{
      [JsonProperty("return_code")]
public 				int

                                                                                     returnCode
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
      [JsonProperty("total_num")]
public 				int

                                                                                     totalNum
 { get; set; }
      [JsonProperty("imgList")]
public 				List<string>

             imgList
 { get; set; }
	}
}
