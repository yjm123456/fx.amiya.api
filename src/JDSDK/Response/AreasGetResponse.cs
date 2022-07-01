using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AreasGetResponse:JdResponse{
      [JsonProperty("code_areas")]
public 				JosAreaListBeanVO[]

                                                                                     codeAreas
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
	}
}
