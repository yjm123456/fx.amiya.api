using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class OmnichannelOrderLocateinfoSearchRequest : JdRequestBase<OmnichannelOrderLocateinfoSearchResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                                                                    		public  		string
  orderIdListJsonStr {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.omnichannel.order.locateinfo.search";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("orderIdListJsonStr", this.            orderIdListJsonStr
);
                                                                            }
    }
}





        
 

