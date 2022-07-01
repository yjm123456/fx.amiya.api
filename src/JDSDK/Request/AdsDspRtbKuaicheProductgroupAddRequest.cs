using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKuaicheProductgroupAddRequest : JdRequestBase<AdsDspRtbKuaicheProductgroupAddResponse>
    {
                                                                                                                                              public  		string
              fee
 {get; set;}
                                                          
                                                          public  		string
              inSearchFee
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              campaignId
 {get; set;}
                                                          
                                                          public  		string
              mobilePriceCoef
 {get; set;}
                                                          
                                                          public  		string
              name
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                           		public  		string
  newAreaIds {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  sourceType {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  adName {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgUrl {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  customTitle {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.kuaiche.productgroup.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("fee", this.            fee
);
                                                                                                        parameters.Add("inSearchFee", this.            inSearchFee
);
                                                                                                        parameters.Add("campaignId", this.            campaignId
);
                                                                                                        parameters.Add("mobilePriceCoef", this.            mobilePriceCoef
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                                                                parameters.Add("newAreaIds", this.            newAreaIds
);
                                                                                                                                                                                                                parameters.Add("skuId", this.            skuId
);
                                                                                                                                                        parameters.Add("adName", this.            adName
);
                                                                                                        parameters.Add("imgUrl", this.            imgUrl
);
                                                                                                        parameters.Add("customTitle", this.            customTitle
);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

