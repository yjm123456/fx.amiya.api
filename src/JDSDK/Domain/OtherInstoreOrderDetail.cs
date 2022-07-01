using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class OtherInstoreOrderDetail:JdObject{
      [JsonProperty("goods_no")]
public 				string

                                                                                     goodsNo
 { get; set; }
      [JsonProperty("difference_remark")]
public 				string

                                                                                     differenceRemark
 { get; set; }
      [JsonProperty("qty")]
public 				int

             qty
 { get; set; }
      [JsonProperty("goods_status")]
public 				string

                                                                                     goodsStatus
 { get; set; }
	}
}
