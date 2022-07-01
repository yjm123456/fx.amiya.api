using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class KuaicheZnMaterialLabelsSearchResponse:JdResponse{
      [JsonProperty("material_label_list")]
public 				List<string>

                                                                                                                     materialLabelList
 { get; set; }
	}
}
