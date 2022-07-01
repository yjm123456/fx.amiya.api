using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class ImPendingOrderDto:JdObject{
      [JsonProperty("ord_no")]
public 				string

                                                                                     ordNo
 { get; set; }
      [JsonProperty("jd_ord_no")]
public 				string

                                                                                                                     jdOrdNo
 { get; set; }
      [JsonProperty("ser_sco")]
public 				int

                                                                                     serSco
 { get; set; }
      [JsonProperty("is_col")]
public 				int

                                                                                     isCol
 { get; set; }
      [JsonProperty("col_t")]
public 				DateTime

                                                                                     colT
 { get; set; }
      [JsonProperty("pop_n")]
public 				string

                                                                                     popN
 { get; set; }
      [JsonProperty("pop_no")]
public 				string

                                                                                     popNo
 { get; set; }
      [JsonProperty("pop_add")]
public 				string

                                                                                     popAdd
 { get; set; }
      [JsonProperty("pop_tel")]
public 				string

                                                                                     popTel
 { get; set; }
      [JsonProperty("pop_con")]
public 				string

                                                                                     popCon
 { get; set; }
      [JsonProperty("del_pro_no")]
public 				string

                                                                                                                     delProNo
 { get; set; }
      [JsonProperty("del_pro_n")]
public 				string

                                                                                                                     delProN
 { get; set; }
      [JsonProperty("del_cit_no")]
public 				string

                                                                                                                     delCitNo
 { get; set; }
      [JsonProperty("del_cit_n")]
public 				string

                                                                                                                     delCitN
 { get; set; }
      [JsonProperty("del_dis_no")]
public 				string

                                                                                                                     delDisNo
 { get; set; }
      [JsonProperty("del_dis_n")]
public 				string

                                                                                                                     delDisN
 { get; set; }
      [JsonProperty("del_tow_no")]
public 				string

                                                                                                                     delTowNo
 { get; set; }
      [JsonProperty("del_tow_n")]
public 				string

                                                                                                                     delTowN
 { get; set; }
      [JsonProperty("del_add")]
public 				string

                                                                                     delAdd
 { get; set; }
      [JsonProperty("des_pro_no")]
public 				string

                                                                                                                     desProNo
 { get; set; }
      [JsonProperty("des_pro_n")]
public 				string

                                                                                                                     desProN
 { get; set; }
      [JsonProperty("des_cit_no")]
public 				string

                                                                                                                     desCitNo
 { get; set; }
      [JsonProperty("des_cit_n")]
public 				string

                                                                                                                     desCitN
 { get; set; }
      [JsonProperty("des_dis_no")]
public 				string

                                                                                                                     desDisNo
 { get; set; }
      [JsonProperty("des_dis_n")]
public 				string

                                                                                                                     desDisN
 { get; set; }
      [JsonProperty("des_tow_no")]
public 				string

                                                                                                                     desTowNo
 { get; set; }
      [JsonProperty("des_tow_n")]
public 				string

                                                                                                                     desTowN
 { get; set; }
      [JsonProperty("sit_no")]
public 				string

                                                                                     sitNo
 { get; set; }
      [JsonProperty("sit_n")]
public 				string

                                                                                     sitN
 { get; set; }
      [JsonProperty("sit_con")]
public 				string

                                                                                     sitCon
 { get; set; }
      [JsonProperty("sit_tel")]
public 				string

                                                                                     sitTel
 { get; set; }
      [JsonProperty("sit_add")]
public 				string

                                                                                     sitAdd
 { get; set; }
      [JsonProperty("col_pro_no")]
public 				string

                                                                                                                     colProNo
 { get; set; }
      [JsonProperty("col_pro_n")]
public 				string

                                                                                                                     colProN
 { get; set; }
      [JsonProperty("col_cit_no")]
public 				string

                                                                                                                     colCitNo
 { get; set; }
      [JsonProperty("col_cit_n")]
public 				string

                                                                                                                     colCitN
 { get; set; }
      [JsonProperty("col_dis_no")]
public 				string

                                                                                                                     colDisNo
 { get; set; }
      [JsonProperty("col_dis_n")]
public 				string

                                                                                                                     colDisN
 { get; set; }
      [JsonProperty("col_tow_no")]
public 				string

                                                                                                                     colTowNo
 { get; set; }
      [JsonProperty("col_tow_n")]
public 				string

                                                                                                                     colTowN
 { get; set; }
      [JsonProperty("col_add")]
public 				string

                                                                                     colAdd
 { get; set; }
      [JsonProperty("col_tel")]
public 				string

                                                                                     colTel
 { get; set; }
      [JsonProperty("col_cod")]
public 				string

                                                                                     colCod
 { get; set; }
      [JsonProperty("rec_pro_no")]
public 				string

                                                                                                                     recProNo
 { get; set; }
      [JsonProperty("rec_pro_n")]
public 				string

                                                                                                                     recProN
 { get; set; }
      [JsonProperty("rec_cit_no")]
public 				string

                                                                                                                     recCitNo
 { get; set; }
      [JsonProperty("rec_cit_n")]
public 				string

                                                                                                                     recCitN
 { get; set; }
      [JsonProperty("rec_dis_no")]
public 				string

                                                                                                                     recDisNo
 { get; set; }
      [JsonProperty("rec_dis_n")]
public 				string

                                                                                                                     recDisN
 { get; set; }
      [JsonProperty("rec_tow_no")]
public 				string

                                                                                                                     recTowNo
 { get; set; }
      [JsonProperty("rec_tow_n")]
public 				string

                                                                                                                     recTowN
 { get; set; }
      [JsonProperty("cus_n")]
public 				string

                                                                                     cusN
 { get; set; }
      [JsonProperty("cus_tel")]
public 				string

                                                                                     cusTel
 { get; set; }
      [JsonProperty("cus_add")]
public 				string

                                                                                     cusAdd
 { get; set; }
      [JsonProperty("est_rec_t")]
public 				DateTime

                                                                                                                     estRecT
 { get; set; }
      [JsonProperty("sum_pri")]
public 					string

                                                                                     sumPri
 { get; set; }
      [JsonProperty("col_pri")]
public 					string

                                                                                     colPri
 { get; set; }
      [JsonProperty("mai_pri")]
public 					string

                                                                                     maiPri
 { get; set; }
      [JsonProperty("bra_pri")]
public 					string

                                                                                     braPri
 { get; set; }
      [JsonProperty("vou_pri")]
public 					string

                                                                                     vouPri
 { get; set; }
      [JsonProperty("ins_pri")]
public 					string

                                                                                     insPri
 { get; set; }
      [JsonProperty("sum_vol")]
public 					string

                                                                                     sumVol
 { get; set; }
      [JsonProperty("lgs_sta")]
public 				int

                                                                                     lgsSta
 { get; set; }
      [JsonProperty("ord_sta")]
public 				int

                                                                                     ordSta
 { get; set; }
      [JsonProperty("is_ver")]
public 				int

                                                                                     isVer
 { get; set; }
      [JsonProperty("ord_fro_typ")]
public 				int

                                                                                                                     ordFroTyp
 { get; set; }
      [JsonProperty("del_t")]
public 				string

                                                                                     delT
 { get; set; }
      [JsonProperty("car_rec_t")]
public 				string

                                                                                                                     carRecT
 { get; set; }
      [JsonProperty("del_fin_t")]
public 				string

                                                                                                                     delFinT
 { get; set; }
      [JsonProperty("rej_t")]
public 				string

                                                                                     rejT
 { get; set; }
      [JsonProperty("exp_at_hom_t")]
public 				string

                                                                                                                                                     expAtHomT
 { get; set; }
      [JsonProperty("cre_ord_t")]
public 				string

                                                                                                                     creOrdT
 { get; set; }
      [JsonProperty("ord_det")]
public 				string

                                                                                     ordDet
 { get; set; }
      [JsonProperty("ika_pac")]
public 				string

                                                                                     ikaPac
 { get; set; }
      [JsonProperty("ika_sal_no")]
public 				string

                                                                                                                     ikaSalNo
 { get; set; }
      [JsonProperty("cre_ord_slo")]
public 				string

                                                                                                                     creOrdSlo
 { get; set; }
      [JsonProperty("ord_dir")]
public 				string

                                                                                     ordDir
 { get; set; }
      [JsonProperty("sa_pafr")]
public 				int

                                                                                     saPafr
 { get; set; }
      [JsonProperty("sa_pafrna")]
public 				string

                                                                                     saPafrna
 { get; set; }
      [JsonProperty("remark")]
public 				string

             remark
 { get; set; }
      [JsonProperty("pac_rem")]
public 				string

                                                                                     pacRem
 { get; set; }
      [JsonProperty("pro_cate_name")]
public 				string

                                                                                                                     proCateName
 { get; set; }
      [JsonProperty("pro_cate_secondname")]
public 				string

                                                                                                                     proCateSecondname
 { get; set; }
      [JsonProperty("pro_cate_firstname")]
public 				string

                                                                                                                     proCateFirstname
 { get; set; }
      [JsonProperty("pro_bran")]
public 				string

                                                                                     proBran
 { get; set; }
      [JsonProperty("pac_num")]
public 				int

                                                                                     pacNum
 { get; set; }
      [JsonProperty("sku_wei")]
public 				double

                                                                                     skuWei
 { get; set; }
	}
}
