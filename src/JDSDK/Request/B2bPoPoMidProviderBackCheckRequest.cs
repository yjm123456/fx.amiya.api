using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class B2bPoPoMidProviderBackCheckRequest : JdRequestBase<B2bPoPoMidProviderBackCheckResponse>
    {
                                                                                                                                                                               public  		string
              thirdPoId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                            		public  		string
  tagName {get; set; }
                                                                                                                                                  public override string ApiName
            {
                get{return "jingdong.b2b.po.PoMidProvider.backCheck";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("thirdPoId", this.            thirdPoId
);
                                                                                                                                                                        parameters.Add("tagName", this.            tagName
);
                                                                            }
    }
}





        
 

