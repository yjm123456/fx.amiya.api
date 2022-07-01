using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AreaTownGetResponse:JdResponse{
      [JsonProperty("town_areas")]
public 				AreaListBeanVO[]

                                                                                     townAreas
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
	}
}
