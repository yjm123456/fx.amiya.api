using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class AreasTownGetRequest : JdRequestBase<AreasTownGetResponse>
    {
                                                                                                                                              public  		Nullable<int>
                                                                                      parentId
 {get; set;}
                                                                                                                                  
                                                                                                               public override string ApiName
            {
                get{return "jingdong.areas.town.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("parent_id", this.                                                                                    parentId
);
                                                                                                                                                                            }
    }
}





        
 

