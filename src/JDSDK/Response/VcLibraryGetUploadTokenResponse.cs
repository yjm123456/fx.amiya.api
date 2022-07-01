using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class VcLibraryGetUploadTokenResponse:JdResponse{
      [JsonProperty("update_token")]
public 				UploadToken

                                                                                     updateToken
 { get; set; }
	}
}
