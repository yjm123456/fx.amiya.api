using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class PopOrderBusinessUploadResponse:JdResponse{
      [JsonProperty("businessupload_result")]
public 				ApiSafResult

                                                                                     businessuploadResult
 { get; set; }
	}
}
