using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ImgzoneImgInfo:JdObject{
      [JsonProperty("category_id")]
public 				long

                                                                                     categoryId
 { get; set; }
      [JsonProperty("created")]
public 				DateTime

             created
 { get; set; }
      [JsonProperty("img_height")]
public 				int

                                                                                     imgHeight
 { get; set; }
      [JsonProperty("img_id")]
public 				string

                                                                                     imgId
 { get; set; }
      [JsonProperty("img_name")]
public 				string

                                                                                     imgName
 { get; set; }
      [JsonProperty("img_size")]
public 				int

                                                                                     imgSize
 { get; set; }
      [JsonProperty("img_type")]
public 				string

                                                                                     imgType
 { get; set; }
      [JsonProperty("img_url")]
public 				string

                                                                                     imgUrl
 { get; set; }
      [JsonProperty("img_width")]
public 				int

                                                                                     imgWidth
 { get; set; }
      [JsonProperty("state")]
public 				int

             state
 { get; set; }
      [JsonProperty("use_flag")]
public 				int

                                                                                     useFlag
 { get; set; }
      [JsonProperty("vender_id")]
public 				long

                                                                                     venderId
 { get; set; }
	}
}
