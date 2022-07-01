using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class AfsServiceSendResponse:JdObject{
      [JsonProperty("afs_no")]
public 				string

                                                                                     afsNo
 { get; set; }
      [JsonProperty("afs_task_no")]
public 				string

                                                                                                                     afsTaskNo
 { get; set; }
      [JsonProperty("ord_no")]
public 				string

                                                                                     ordNo
 { get; set; }
      [JsonProperty("inv_no")]
public 				string

                                                                                     invNo
 { get; set; }
      [JsonProperty("buy_pri")]
public 					string

                                                                                     buyPri
 { get; set; }
      [JsonProperty("cus_n")]
public 				string

                                                                                     cusN
 { get; set; }
      [JsonProperty("cus_mp")]
public 				string

                                                                                     cusMp
 { get; set; }
      [JsonProperty("prov_no")]
public 				string

                                                                                     provNo
 { get; set; }
      [JsonProperty("prov_n")]
public 				string

                                                                                     provN
 { get; set; }
      [JsonProperty("cty_no")]
public 				string

                                                                                     ctyNo
 { get; set; }
      [JsonProperty("cty_n")]
public 				string

                                                                                     ctyN
 { get; set; }
      [JsonProperty("cnty_no")]
public 				string

                                                                                     cntyNo
 { get; set; }
      [JsonProperty("cnty_n")]
public 				string

                                                                                     cntyN
 { get; set; }
      [JsonProperty("tn_no")]
public 				string

                                                                                     tnNo
 { get; set; }
      [JsonProperty("tn_n")]
public 				string

                                                                                     tnN
 { get; set; }
      [JsonProperty("add")]
public 				string

             add1
 { get; set; }
      [JsonProperty("del_t")]
public 				string

                                                                                     delT
 { get; set; }
      [JsonProperty("has_inv")]
public 				int

                                                                                     hasInv
 { get; set; }
      [JsonProperty("aud_typ")]
public 				string

                                                                                     audTyp
 { get; set; }
      [JsonProperty("que_desc")]
public 				string

                                                                                     queDesc
 { get; set; }
      [JsonProperty("app_t")]
public 				string

                                                                                     appT
 { get; set; }
      [JsonProperty("cus_exp")]
public 				string

                                                                                     cusExp
 { get; set; }
      [JsonProperty("cus_exp_t")]
public 				string

                                                                                                                     cusExpT
 { get; set; }
      [JsonProperty("afs_sta")]
public 				int

                                                                                     afsSta
 { get; set; }
      [JsonProperty("app_num")]
public 				int

                                                                                     appNum
 { get; set; }
      [JsonProperty("bef_fin_rs")]
public 				string

                                                                                                                     befFinRs
 { get; set; }
      [JsonProperty("afs_det")]
public 				string

                                                                                     afsDet
 { get; set; }
	}
}
