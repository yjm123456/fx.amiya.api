using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class AreaProvinceGetResponse:JdResponse{
      [JsonProperty("province_areas")]
public 				AreaListBeanVO[]

                                                                                     provinceAreas
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
	}
}
