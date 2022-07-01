using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class UnitPromoDetailResultDto:JdObject{
      [JsonProperty("ware_promotion")]
public 				WarePromotionDto

                                                                                     warePromotion
 { get; set; }
      [JsonProperty("success")]
public 				bool

             success
 { get; set; }
      [JsonProperty("result_code")]
public 				int

                                                                                     resultCode
 { get; set; }
      [JsonProperty("result_message")]
public 				string

                                                                                     resultMessage
 { get; set; }
	}
}
