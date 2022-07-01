using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CmpArticleApplyRequest : JdRequestBase<CmpArticleApplyResponse>
    {
                                                                                                                                              public  		Nullable<int>
              id
 {get; set;}
                                                          
                                                                                           public  		string
              remark
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              applyType
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.cmp.article.apply";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("id", this.            id
);
                                                                                                                                                        parameters.Add("remark", this.            remark
);
                                                                                                        parameters.Add("applyType", this.            applyType
);
                                                                            }
    }
}





        
 

