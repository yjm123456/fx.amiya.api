using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AreaCountyGetResponse:JdResponse{
      [JsonProperty("county_areas")]
public 				AreaListBeanVO[]

                                                                                     countyAreas
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
	}
}
