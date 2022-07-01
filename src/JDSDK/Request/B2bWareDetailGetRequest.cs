using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bWareDetailGetRequest : JdRequestBase<B2bWareDetailGetResponse>
    {
                                                                                                                                              public  		string
              channelEnum
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                                                        		public  		string
  bSkuGetExtendEnumsKyes {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   		public  		string
  bSkuGetEnumsKeys {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  jdSkuIdsKeys {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.b2b.ware.detail.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channelEnum", this.            channelEnum
);
                                                                                                                                                                                                                parameters.Add("bSkuGetExtendEnumsKyes", this.            bSkuGetExtendEnumsKyes
);
                                                                                                                                                                                                                                                                        parameters.Add("bSkuGetEnumsKeys", this.            bSkuGetEnumsKeys
);
                                                                                                                                                                        parameters.Add("jdSkuIdsKeys", this.            jdSkuIdsKeys
);
                                                                                                    }
    }
}





        
 

