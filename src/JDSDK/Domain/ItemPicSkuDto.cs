using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemPicSkuDto:JdObject{
      [JsonProperty("image_path_dto_list")]
public 				List<string>

                                                                                                                                                     imagePathDtoList
 { get; set; }
      [JsonProperty("sku_id")]
public 				string

                                                                                     skuId
 { get; set; }
	}
}
