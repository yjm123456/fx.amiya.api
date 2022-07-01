using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspKcAdAddshopadRequest : JdRequestBase<DspKcAdAddshopadResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                		public  		string
  name {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  skuId {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  imgUrl {get; set; }
                                                                                                                                                                                                public  		Nullable<long>
              adGroupId
 {get; set;}
                                                          
                                                          public  		string
              url
 {get; set;}
                                                          
                                                                                                                            public  		string
              showSalesWord
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dsp.kc.ad.addshopad";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("skuId", this.            skuId
);
                                                                                                        parameters.Add("imgUrl", this.            imgUrl
);
                                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                        parameters.Add("url", this.            url
);
                                                                                                                                                                                                        parameters.Add("showSalesWord", this.            showSalesWord
);
                                                                            }
    }
}





        
 

