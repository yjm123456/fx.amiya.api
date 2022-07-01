using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DspAdkckeywordUpdateKeyWordsRequest : JdRequestBase<DspAdkckeywordUpdateKeyWordsResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  name {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  price {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  type {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  mobilePrice {get; set; }
                                                                                                                                                                                                public  		string
              adGroupId
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.dsp.adkckeyword.updateKeyWords";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("price", this.            price
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("mobilePrice", this.            mobilePrice
);
                                                                                                                                                        parameters.Add("adGroupId", this.            adGroupId
);
                                                                                                                            }
    }
}





        
 

