using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
			using Jd.Api.Domain;
			namespace Jd.Api.Response
{

public class SearchWareResponse:JdResponse{
      [JsonProperty("Summary")]
public 				Summary

             Summary
 { get; set; }
      [JsonProperty("ObjA_Price")]
public 				List<string>

                                                                                     objAPrice
 { get; set; }
      [JsonProperty("ObjExtAttrCollection")]
public 				List<string>

             ObjExtAttrCollection
 { get; set; }
      [JsonProperty("Paragraph")]
public 				List<string>

             Paragraph
 { get; set; }
	}
}
