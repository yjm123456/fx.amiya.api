using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ItemPicSkuDtoLucency:JdObject{
      [JsonProperty("image_path_dto_list_lucency")]
public 				List<string>

                                                                                                                                                                                     imagePathDtoListLucency
 { get; set; }
      [JsonProperty("sku_id_lucency")]
public 				string

                                                                                                                     skuIdLucency
 { get; set; }
	}
}
