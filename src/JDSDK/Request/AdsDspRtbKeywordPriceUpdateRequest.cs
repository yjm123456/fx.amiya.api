using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AdsDspRtbKeywordPriceUpdateRequest : JdRequestBase<AdsDspRtbKeywordPriceUpdateResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                               		public  		string
  ids {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              campaignType
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              putType
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  type {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  change {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  keywordPrice {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  devType {get; set; }
                                                                                                                                                                                                public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                              public override string ApiName
            {
                get{return "jingdong.ads.dsp.rtb.keyword.price.update";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                                                parameters.Add("campaignType", this.            campaignType
);
                                                                                                        parameters.Add("putType", this.            putType
);
                                                                                                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("change", this.            change
);
                                                                                                        parameters.Add("keywordPrice", this.            keywordPrice
);
                                                                                                        parameters.Add("devType", this.            devType
);
                                                                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                                                                                                                                                                                                                                                            }
    }
}





        
 

