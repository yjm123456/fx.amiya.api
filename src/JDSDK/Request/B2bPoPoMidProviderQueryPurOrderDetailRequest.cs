using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bPoPoMidProviderQueryPurOrderDetailRequest : JdRequestBase<B2bPoPoMidProviderQueryPurOrderDetailResponse>
    {
                                                                                                                                                                               public  		string
              poId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  tagName {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.b2b.po.PoMidProvider.queryPurOrderDetail";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("poId", this.            poId
);
                                                                                                                                                                        parameters.Add("tagName", this.            tagName
);
                                                                            }
    }
}





        
 

