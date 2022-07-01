using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
													namespace Jd.Api.Response
{

public class ImgzonePictureUploadResponse:JdResponse{
      [JsonProperty("return_code")]
public 				int

                                                                                     returnCode
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
      [JsonProperty("picture_id")]
public 				string

                                                                                     pictureId
 { get; set; }
      [JsonProperty("picture_url")]
public 				string

                                                                                     pictureUrl
 { get; set; }
	}
}
