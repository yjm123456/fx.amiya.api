using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ImgzoneCategory:JdObject{
      [JsonProperty("cate_id")]
public 				long

                                                                                     cateId
 { get; set; }
      [JsonProperty("cate_name")]
public 				string

                                                                                     cateName
 { get; set; }
      [JsonProperty("cate_level")]
public 				int

                                                                                     cateLevel
 { get; set; }
      [JsonProperty("parent_cate_id")]
public 				long

                                                                                                                     parentCateId
 { get; set; }
      [JsonProperty("cate_order")]
public 				int

                                                                                     cateOrder
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("modified")]
public 				DateTime

             modified
 { get; set; }
	}
}
