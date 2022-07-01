using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
									using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ImgzoneUserinfoQueryResponse:JdResponse{
      [JsonProperty("return_code")]
public 				int

                                                                                     returnCode
 { get; set; }
      [JsonProperty("desc")]
public 				string

             desc
 { get; set; }
      [JsonProperty("userInfo")]
public 				ImgzoneZoneInfo

             userInfo
 { get; set; }
	}
}
