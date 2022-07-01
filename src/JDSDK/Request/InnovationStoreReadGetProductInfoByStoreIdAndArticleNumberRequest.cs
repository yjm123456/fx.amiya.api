using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class InnovationStoreReadGetProductInfoByStoreIdAndArticleNumberRequest : JdRequestBase<InnovationStoreReadGetProductInfoByStoreIdAndArticleNumberResponse>
    {
                                                                                  public  		string
              paramStrin
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.innovation.store.read.getProductInfoByStoreIdAndArticleNumber";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("paramStrin", this.            paramStrin
);
                                                    }
    }
}





        
 

