using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ResponseOrderOtherDetail:JdObject{
      [JsonProperty("josl_good_no")]
public 				string

                                                                                                                     joslGoodNo
 { get; set; }
      [JsonProperty("isv_good_no")]
public 				string

                                                                                                                     isvGoodNo
 { get; set; }
      [JsonProperty("qty")]
public 				int

             qty
 { get; set; }
      [JsonProperty("goods_status")]
public 				string

                                                                                     goodsStatus
 { get; set; }
      [JsonProperty("difference_remark")]
public 				string

                                                                                     differenceRemark
 { get; set; }
	}
}
