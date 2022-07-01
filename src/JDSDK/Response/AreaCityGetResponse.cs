using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AreaCityGetResponse:JdResponse{
      [JsonProperty("city_areas")]
public 				AreaListBeanVO[]

                                                                                     cityAreas
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
	}
}
