using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ReceivingTask:JdObject{
      [JsonProperty("goods_no")]
public 				string

                                                                                     goodsNo
 { get; set; }
      [JsonProperty("goods_status")]
public 				string

                                                                                     goodsStatus
 { get; set; }
      [JsonProperty("qty")]
public 				int

             qty
 { get; set; }
      [JsonProperty("expected_qty")]
public 				int

                                                                                     expectedQty
 { get; set; }
      [JsonProperty("difference_remark")]
public 				string

                                                                                     differenceRemark
 { get; set; }
	}
}
