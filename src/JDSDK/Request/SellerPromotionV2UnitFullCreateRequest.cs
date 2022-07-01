using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionV2UnitFullCreateRequest : JdRequestBase<SellerPromotionV2UnitFullCreateResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                          public  		string
                                                                                      requestId
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                         public  		string
                                                                                      promoName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      beginTime
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
              slogan
 {get; set;}
                                                          
                                                          public  		string
              comment
 {get; set;}
                                                          
                                                          public  		string
              link
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              plusMember
 {get; set;}
                                                          
                                                          public  		string
                                                                                                                      allowOthersOperate
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      allowOthersCheck
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                                                      allowOtherUserOperate
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                                                                                      allowOtherUserCheck
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                                                      needManualCheck
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                      freqBound
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      perMaxNum
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                                                      perMinNum
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                      propType
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      propNum
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      propUsedWay
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                                                      couponValidDays
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
                                                                                                                      tokenUseNum
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      userPins
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                                                      promoAreaType
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      promoAreas
 {get; set;}
                                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  promoPrice {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  limitNum {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.seller.promotion.v2.unit.full.create";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                        parameters.Add("request_id", this.                                                                                    requestId
);
                                                                                                                                                                                                                                                                        parameters.Add("promo_name", this.                                                                                    promoName
);
                                                                                                        parameters.Add("begin_time", this.                                                                                    beginTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                                                                                                        parameters.Add("slogan", this.            slogan
);
                                                                                                        parameters.Add("comment", this.            comment
);
                                                                                                        parameters.Add("link", this.            link
);
                                                                                                                                                        parameters.Add("plusMember", this.            plusMember
);
                                                                                                        parameters.Add("allow_others_operate", this.                                                                                                                    allowOthersOperate
);
                                                                                                        parameters.Add("allow_others_check", this.                                                                                                                    allowOthersCheck
);
                                                                                                        parameters.Add("allow_other_user_operate", this.                                                                                                                                                    allowOtherUserOperate
);
                                                                                                        parameters.Add("allow_other_user_check", this.                                                                                                                                                    allowOtherUserCheck
);
                                                                                                        parameters.Add("need_manual_check", this.                                                                                                                    needManualCheck
);
                                                                                                        parameters.Add("freq_bound", this.                                                                                    freqBound
);
                                                                                                        parameters.Add("per_max_num", this.                                                                                                                    perMaxNum
);
                                                                                                        parameters.Add("per_min_num", this.                                                                                                                    perMinNum
);
                                                                                                        parameters.Add("prop_type", this.                                                                                    propType
);
                                                                                                        parameters.Add("prop_num", this.                                                                                    propNum
);
                                                                                                        parameters.Add("prop_used_way", this.                                                                                                                    propUsedWay
);
                                                                                                        parameters.Add("coupon_valid_days", this.                                                                                                                    couponValidDays
);
                                                                                                        parameters.Add("token_use_num", this.                                                                                                                    tokenUseNum
);
                                                                                                        parameters.Add("user_pins", this.                                                                                    userPins
);
                                                                                                        parameters.Add("promo_area_type", this.                                                                                                                    promoAreaType
);
                                                                                                        parameters.Add("promo_areas", this.                                                                                    promoAreas
);
                                                                                                                                                                                                                parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("promo_price", this.                                                                                    promoPrice
);
                                                                                                        parameters.Add("limit_num", this.                                                                                    limitNum
);
                                                                                                    }
    }
}





        
 

