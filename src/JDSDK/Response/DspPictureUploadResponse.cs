using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class DspPictureUploadResponse:JdResponse{
      [JsonProperty("uploadPic_result")]
public 				DspResult

                                                                                     uploadPicResult
 { get; set; }
	}
}
