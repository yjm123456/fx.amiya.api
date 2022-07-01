using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class CmpArticleGetstatustimelistRequest : JdRequestBase<CmpArticleGetstatustimelistResponse>
    {
                                                                                  public  		string
              ids
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.cmp.article.getstatustimelist";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("ids", this.            ids
);
                                                                                                    }
    }
}





        
 

