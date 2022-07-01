using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
																			namespace Jd.Api.Response
{

public class ImgzonePictureDeleteResponse:JdResponse{
      [JsonProperty("return_code")]
public 				int

                                                                                     returnCode
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
      [JsonProperty("success_num")]
public 				int

                                                                                     successNum
 { get; set; }
      [JsonProperty("illegal")]
public 				string

             illegal
 { get; set; }
      [JsonProperty("referenced")]
public 				string

             referenced
 { get; set; }
      [JsonProperty("fail")]
public 				string

             fail
 { get; set; }
	}
}
