using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class ErsFangUploadImgResponse:JdResponse{
      [JsonProperty("uploadimg_result")]
public 				ImgUpLoadResult

                                                                                     uploadimgResult
 { get; set; }
	}
}
